using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NewLynn_GymDb.Models;
using System.Reflection.Emit;

namespace NewLynn_GymDb.Areas.Identity.Data;

public class NewLynn_GymDbContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
{
    public NewLynn_GymDbContext(DbContextOptions<NewLynn_GymDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



    public DbSet<NewLynn_GymDb.Models.Attendance>? Attendance { get; set; }


    public DbSet<NewLynn_GymDb.Models.Transaction>? Transaction { get; set; }


    public DbSet<NewLynn_GymDb.Models.Member>? Member { get; set; }


    public DbSet<NewLynn_GymDb.Models.Employee>? Employee { get; set; }
}