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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Relation One Student To One Account 
        modelBuilder.Entity<Student>()
        .HasOne(s => s.Account)
        .WithOne(a => a.Student)
        .HasForeignKey<Account>(fk => fk.StudentNim);
    }
}
