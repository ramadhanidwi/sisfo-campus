using sisfo_campus.Contexts;
using sisfo_campus.Models;
using sisfo_campus.ViewModels;
using sisfo_campus.Handlers;
using Microsoft.EntityFrameworkCore;

namespace sisfo_campus.Repositories.Data;

public class AccountRepository : GeneralRepository<int, Account>
{
    private readonly MyContext context;
    private readonly StudentRepository studentRepository;

    public AccountRepository(MyContext context, StudentRepository studentRepository) : base(context)
    {
        this.context = context;
        this.studentRepository = studentRepository;
    }

    public async Task<bool> Login(LoginVM loginVM)
    {
        var getAccounts = await context.Students
            .Include(s => s.Account)
            .Select(s => new LoginVM
            {
                Email = s.Email,
                Password = s.Account.Password
            }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

        //var getAccounts = context.Employees.Join(
        //    context.Accounts,
        //    e => e.NIK,
        //    a => a.EmployeeNIK,
        //    (e, a) => new LoginVM
        //    {
        //        Email = e.Email,
        //        Password = a.Password
        //    }).FirstOrDefault(a => a.Email == loginVM.Email);

        if (getAccounts is null)
        {
            return false;
        }
        return Hashing.ValidatePassword(loginVM.Password, getAccounts.Password);
    }

    public async Task<int> Register(RegisterVM registerVM)
    {
        int result = 0;
        Faculty faculty = new Faculty
        {
            Code = registerVM.CodeFaculty,
            Name = registerVM.NameFaculty,            
            Building = registerVM.Building,
            PhoneNumber = registerVM.PhoneNumberFaculty
        };

        // Bikin kondisi untuk mengecek apakah data faculty sudah ada
        if (await context.Faculties.AnyAsync(f => f.Name == faculty.Name))
        {
            faculty.Code= context.Faculties
                .FirstOrDefault(f => f.Name == faculty.Name)
                .Code;
        }
        else
        {
            await context.Faculties.AddAsync(faculty);
            result = context.SaveChanges();
        }

        Major major = new Major
        {
            Code = registerVM.CodeMajor,
            Name = registerVM.NameMajor,
            FacultyCode = faculty.Code
            

        };
        await context.Majors.AddAsync(major);
        result = await context.SaveChangesAsync();

        Student student= new Student
        {
            Nim = registerVM.Nim,
            FirstName = registerVM.FirstName,
            LastName = registerVM.LastName,
            BirthDate = registerVM.BirthDate,            
            Gender = registerVM.Gender,
            Email = registerVM.Email,
            PhoneNumber = registerVM.PhoneNumber,
            Address = registerVM.Address,
            MajorCode = major.Code
        };
        await context.Students.AddAsync(student);
        result = await context.SaveChangesAsync();

        Account account = new Account
        {
            StudentNim = student.Nim,
            Password = Hashing.HashPassword(registerVM.Password)
        };
        await context.Accounts.AddAsync(account);
        result = await context.SaveChangesAsync();

        AccountRole accountRole = new AccountRole
        {
            AccountId = student.Nim,
            RoleId = 3
        };

        await context.AccountRoles.AddAsync(accountRole);
        result = await context.SaveChangesAsync();

        return result;
    }

    //public async Task<List<AccountEmployeeVM>> GetEmployeeAccount()
    //{
    //    var results = (from a in GetAll()
    //                   join e in empRepository.GetAll()
    //                   on a.EmployeeNIK equals e.NIK
    //                   select new AccountEmployeeVM
    //                   {
    //                       Email = e.Email,
    //                       Password = a.Password
    //                   }).ToList();
    //    return results;
    //}

    public async Task<UserDataVM> GetUserData(string email)
    {
        //Menggunakan Method Syntax
        //var userdataMethod = context.Employees
        //  .Join(context.Accounts,
        //  e => e.NIK,
        //  a => a.EmployeeNIK,
        //  (e, a) => new { e, a })
        //  .Join(context.AccountRoles,
        //  ea => ea.a.EmployeeNIK,
        //  ar => ar.AccountNIK,
        //  (ea, ar) => new { ea, ar })
        //  .Join(context.Roles,
        //  eaar => eaar.ar.RoleId,
        //  r => r.Id,
        //  (eaar, r) => new UserDataVM
        //  {
        //      Email = eaar.ea.e.Email,
        //      FullName = String.Concat(eaar.ea.e.FirstName, eaar.ea.e.LastName),
        //      Role = r.Name
        //  }).FirstOrDefault(u => u.Email == email);

        //Menggunakan Query Syntax 
        var userdata = await (from s in context.Students //seharusnya jangan pake context tapi import dari repository nya table bersangkutan
                              join a in context.Accounts
                              on s.Nim equals a.StudentNim
                              join ar in context.AccountRoles
                              on a.StudentNim equals ar.AccountId
                              join r in context.Roles
                              on ar.RoleId equals r.Id
                              where s.Email == email
                              select new UserDataVM
                              {
                                  Email = s.Email,
                                  FullName = string.Concat(s.FirstName, " ", s.LastName)
                              }).FirstOrDefaultAsync();

        return userdata;
    }

    public async Task<List<string>> GetRolesByNIK(string email)
    {
        var getNIK = await context.Students.FirstOrDefaultAsync(s => s.Email == email);
        return context.AccountRoles.Where(ar => ar.AccountId == getNIK.Nim).Join(
            context.Roles,
            ar => ar.RoleId,
            r => r.Id,
            (ar, r) => r.Name).ToList();
    }
}


