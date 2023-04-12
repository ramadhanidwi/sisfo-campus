using System;
using Microsoft.EntityFrameworkCore;
using sisfo_campus.Models;


namespace sisfo_campus.Contexts;

public class MyContext : DbContext
{
	public MyContext(DbContextOptions<MyContext> options) : base(options)
	{
		
	}
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<Assignment> Assignments{ get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<AttachmentFile> AttachmentFiles{ get; set; }

    //Fluent APi
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Relation One Student To One Account 
        modelBuilder.Entity<Student>()
        .HasOne(s => s.Account)
        .WithOne(a => a.Student)
        .HasForeignKey<Account>(fk => fk.StudentNim);


        //menambahkan data secara default ke tabel 
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },

            new Role
            {
                Id = 2,
                Name = "Lecturer"
            },

            new Role
            {
                Id = 3,
                Name = "Student"
            });

        ////Membuat atribute menjadi unique
        //modelBuilder.Entity<Student>().HasAlternateKey(s => new        //karena ada 2 atribut unique maka menggunakan anonymous function
        //{
        //    s.Email,
        //    s.PhoneNumber,
        //});
    }
}
