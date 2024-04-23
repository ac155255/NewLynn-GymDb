using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NewLynn_GymDb.Models;
using System.Reflection.Emit;

namespace NewLynn_GymDb.Areas.Identity.Data;

public class NewLynn_GymDbContext : IdentityDbContext<IdentityUser>
{
    public NewLynn_GymDbContext(DbContextOptions<NewLynn_GymDbContext> options)
        : base(options)
    {
      
    }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attendence>().ToTable("Attendance");
        //Sample data

        modelBuilder.Entity<Attendence>().HasData(
            new Attendence { AttendenceID = 123, MemberID = 12, EmployeeID = 12, AttendenceDate = DateTime.Now, Status = "Present" },
            new Attendence { AttendenceID = 321, MemberID = 123, EmployeeID = 05, AttendenceDate = DateTime.Now, Status = "Absent" },
            new Attendence { AttendenceID = 576, MemberID = 345, EmployeeID = 22, AttendenceDate = DateTime.Now, Status = "Absent"}
            

            ) ;





        modelBuilder.Entity<Employee>().ToTable("Employee");
        //Sample data

        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 12, FirstName = "Sarah", LastName = "Dawon", HireDate = DateTime.Now, Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", Position = "Manager", Salary = "$27.50/Hr"},
             new Employee { EmployeeId = 05, FirstName = "Ranav", LastName = "Singh", HireDate = DateTime.Now, Address = "1634 Great North Road", Email = "wfuw3hf@gmail.com", PhoneNumber = "022383968", Position = "Front Desk", Salary = "$27.50/Hr" },
              new Employee { EmployeeId = 22, FirstName = "Sarah", LastName = "Dawon", HireDate = DateTime.Now, Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", Position = "Manager", Salary = "$27.50/Hr" }



            );


        modelBuilder.Entity<Member>().ToTable("Member");
        //Sample data

        modelBuilder.Entity<Member>().HasData(
            new Member { MemberId = 12, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime (2000-06-07), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType = "Monthly", PaymentInformation = "4929 1234 5678 9012", },
            new Member { MemberId = 123, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime(2000 - 06 - 07), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType = "Monthly", PaymentInformation = "4929 1234 5678 9012", },
            new Member { MemberId = 345, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime(2000 - 06 - 07), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType = "Monthly", PaymentInformation = "4929 1234 5678 9012",}

            );
        modelBuilder.Entity<Transaction>().ToTable("Transaction");
        //Sample data

        modelBuilder.Entity<Transaction>().HasData(
           new Transaction { TransactionId = 321, MemberID = 12, EmployeeID = 12, Amount = "100.00" , PaymentMethod = "Credit Card", TransactionDate = DateTime.Now },
           new Transaction { TransactionId = 987, MemberID = 123, EmployeeID = 05, Amount = "100.00", PaymentMethod = "Credit Card", TransactionDate = DateTime.Now },
           new Transaction { TransactionId = 654, MemberID = 345, EmployeeID = 22, Amount = "100.00", PaymentMethod = "Credit Card", TransactionDate = DateTime.Now }
            );
    }
   

    public DbSet<NewLynn_GymDb.Models.Attendence>? Attendence { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Transaction>? Transaction { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Member>? Member { get; set; }
   

    public DbSet<NewLynn_GymDb.Models.Employee>? Employee { get; set; }
}