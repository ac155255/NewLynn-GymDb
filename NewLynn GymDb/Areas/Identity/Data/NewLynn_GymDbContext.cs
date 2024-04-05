using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewLynn_GymDb.Models;

namespace NewLynn_GymDb.Areas.Identity.Data;

public class NewLynn_GymDbContext : IdentityDbContext<IdentityUser>
{
    public NewLynn_GymDbContext(DbContextOptions<NewLynn_GymDbContext> options)
        : base(options)
    {
      
    }
   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
   

    public DbSet<NewLynn_GymDb.Models.Attendence>? Attendence { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Transaction>? Transaction { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Member>? Member { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Employee>? Employee { get; set; }
}