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
}
