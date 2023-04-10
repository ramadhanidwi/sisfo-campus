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
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Role> Roles { get; set; }
    /*    public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }*/
    /*
        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                },
                new Role
                {
                    Id = 2,
                    Name = "Lecturer",
                },
                new Role
                {
                    Id = 3,
                    Name = "Student",
                });

            // Membuat atribute menjadi unique
            modelBuilder.Entity<Student>().HasIndex(e => new
            {
                e.Email,
                e.PhoneNumber
            }).IsUnique();


            // Relasi one Employee ke one Account 
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Account)
                .WithOne(a => a.Student)
                .HasForeignKey<Account>(fk => fk.StudentNim);

        }
    */
}
