using NewLynn_GymDb.Areas.Identity.Data;
using NewLynn_GymDb.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace NewLynn_GymDb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(NewLynn_GymDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any members.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
            new Member{LastName="Johnson",FirstName="Emily",Address="456 Oak Avenue, Metropolis",PhoneNumber="02242387456",Email="emily.johnson@example.com",DateOfBirth=DateTime.Parse("19/03/1999"),MembershipType=MembershipType.Yearly,JoinDate=DateTime.Parse("30/06/2024"),PaymentInformation=PaymentInformation.Card },
            new Member{LastName="Williams",FirstName="Michael",Address="789 Pine Road, Gotham",PhoneNumber="022423832334",Email=" michael.williams@example.com",DateOfBirth=DateTime.Parse("9/07/1992"),MembershipType=MembershipType.Yearly,JoinDate=DateTime.Parse("27/06/2024"),PaymentInformation=PaymentInformation.Card },
             new Member{LastName="Brown",FirstName="Sarah",Address="101 Birch Boulevard, Smallville",PhoneNumber="02242383238",Email="sarah.brown@example.com",DateOfBirth=DateTime.Parse("19/03/1999"),MembershipType=MembershipType.Monthly,JoinDate=DateTime.Parse("29/06/2024"),PaymentInformation=PaymentInformation.Cash }

            };
            foreach (Member s in members)
            {
                context.Members.Add(s);
            }
            context.SaveChanges();

            // Look for any employees.
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new Employee[]
            {
            new Employee{LastName="Baker",FirstName="Anna",HireDate=DateTime.Parse("27/06/2024"),Address="1458 great north road",Position=Position.Receptionist,Email="anna.baker@example.com",PhoneNumber="02242387453",Salary="$25.70" },
            new Employee{LastName="Carter",FirstName="John",HireDate=DateTime.Parse("29/06/2024"),Address="3287 great south road",Position=Position.Trainer,Email="john.carter@example.com",PhoneNumber="02242383234",Salary="$33.90" },
            new Employee{LastName="Evans",FirstName="Laura",HireDate=DateTime.Parse("29/06/2024"),Address="123 Maple Street road",Position=Position.Manager,Email="laura.evans@example.com",PhoneNumber="02242387453",Salary="$35.90" },

            };
            foreach (Employee c in employees)
            {
                context.Employees.Add(c);
            }
            context.SaveChanges();

            // Look for any attendances.
            if (context.Attendances.Any())
            {
                return;   // DB has been seeded
            }

            var attendances = new Attendance[]
            {
            new Attendance{AttendanceDate=DateTime.Parse("27/06/2024 12:00:00 am"),Status=Status.Present,MemberId= 3,EmployeeId= 4, },
             new Attendance{AttendanceDate=DateTime.Parse("05/07/2024 12:00:00 am"),Status=Status.Absent,MemberId= 4,EmployeeId = 5},
              new Attendance{AttendanceDate=DateTime.Parse("27/06/2024 12:00:00 am"),Status=Status.Present,MemberId = 5, EmployeeId = 3},

            };
            foreach (Attendance e in attendances)
            {
                context.Attendances.Add(e);
            }
            context.SaveChanges();

            // Look for any transactions.
            if (context.Transaction.Any())
            {
                return;   // DB has been seeded
            }

            var transactions = new Transaction[]
            {
            new Transaction{MemberID= 3,EmployeeID = 4,Amount="$80.00",PaymentMethod=PaymentMethod.Card,TransactionDate=DateTime.Parse("27/06/2024 12:00:00 am") },
            new Transaction{MemberID= 4,EmployeeID = 5,Amount="$500.00",PaymentMethod=PaymentMethod.Cash,TransactionDate=DateTime.Parse("0/07/2024 12:00:00 am") },
            new Transaction{MemberID= 5,EmployeeID = 5,Amount="$20.00",PaymentMethod=PaymentMethod.Cash,TransactionDate=DateTime.Parse("29/06/2024 12:00:00 am") },


            };
            foreach (Transaction e in transactions)
            {
                context.Transaction.Add(e);
            }
            context.SaveChanges();
        }
    }
}