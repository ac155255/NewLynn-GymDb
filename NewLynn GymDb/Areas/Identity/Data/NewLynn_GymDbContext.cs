using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewLynn_GymDb.Models;
using System.Reflection.Emit;
using NewLynn_GymDb.Areas.Identity.Pages;


namespace NewLynn_GymDb.Areas.Identity.Data;

public class NewLynn_GymDbContext : IdentityDbContext<ApplicationUser>
{
    public NewLynn_GymDbContext(DbContextOptions<NewLynn_GymDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    internal static Task<string?> ToListAsync()
    {
        throw new NotImplementedException();
    }

    


    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        //builder.Property(u => u.FirstName).HasMaxLength(20);
        //builder.Property(u => u.LastName).HasMaxLength(20);
    }

   
}