using Microsoft.EntityFrameworkCore;
using sisfo_campus.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Data;

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
    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<Course> Courses { get; set; }

    //Fluent APi
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
        modelBuilder.Entity<Student>().HasIndex(s => new
        {
            s.Email,
            s.PhoneNumber
        }).IsUnique();

        //Relation One Student To One Account 
        modelBuilder.Entity<Student>()
        .HasOne(s => s.Account)
        .WithOne(a => a.Student)
        .HasForeignKey<Account>(fk => fk.StudentNim);


    }
}