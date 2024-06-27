﻿namespace NewLynn_GymDb.Areas.Identity.Data
{
    using NewLynn_GymDb;
    using NewLynn_GymDb.Models;
    using System;
    using System.Diagnostics;
    using System.Linq;

   

        public static class DbInitializer
        {
            public static void Initialize(NewLynn_GymDbContext context)
            {
                context.Database.EnsureCreated();

                if (context.Attendance.Any())
                {
                    return;   // DB has been seeded
                }

                var Attendance = new Attendance[]
                {
                new Attendance { AttendanceID = 1, MemberID = 1, EmployeeID = 1, AttendanceDate = DateTime.Now, Status = status.Present},
                new Attendance { AttendanceID = 321, MemberID = 123, EmployeeID = 05, AttendanceDate = DateTime.Now, Status = status.Absent},
                new Attendance { AttendanceID = 576, MemberID = 345, EmployeeID = 22, AttendanceDate = DateTime.Now, Status = status.Present }
                };
                foreach (Attendance s in Attendance)
                {
                    context.Attendance.Add(s);
                }
                context.SaveChanges();

                var Employees = new Employee[]
                {
                new Employee { EmployeeId = 12, FirstName = "Sarah", LastName = "Dawon", HireDate = DateTime.Now, Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", Position = Position.Manager, Salary = "$27.50/Hr"},
                new Employee { EmployeeId = 05, FirstName = "Ranav", LastName = "Singh", HireDate = DateTime.Now, Address = "1634 Great North Road", Email = "wfuw3hf@gmail.com", PhoneNumber = "022383968", Position = Position.Receptionist, Salary = "$27.50/Hr" },
                new Employee { EmployeeId = 22, FirstName = "Yash", LastName = "Chand", HireDate = DateTime.Now, Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", Position = Position.Cleaner, Salary = "$27.50/Hr" }
                };
                foreach (Employee c in Employees)
                {
                    context.Employee.Add(c);
                }
                context.SaveChanges();

                var Members = new Member[]
                {
                new Member { MemberId = 12, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime(2000, 6, 7), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType =MembershipType.Weekly, PaymentInformation =PaymentInformation.Card },
                new Member { MemberId = 123, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime(2000, 6, 7), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType = MembershipType.Yearly, PaymentInformation = PaymentInformation.Card  },
                new Member { MemberId = 345, FirstName = "Sarah", LastName = "Dawon", DateOfBirth = new DateTime(2000, 6, 7), Address = "1603 Great South Road", Email = "ac7egc33@gmail.com", PhoneNumber = "0223583943", JoinDate = DateTime.Now, MembershipType =MembershipType.Monthly, PaymentInformation = PaymentInformation.Cash }
                };
                foreach (Member e in Members)
                {
                    context.Member.Add(e);
                }
                context.SaveChanges();

                var Transactions = new Transaction[]
                {
                new Transaction { TransactionId = 321, MemberID = 12, EmployeeID = 12, Amount = "100.00" , PaymentMethod = PaymentMethod.Card, TransactionDate = DateTime.Now },
                new Transaction { TransactionId = 987, MemberID = 123, EmployeeID = 05, Amount = "100.00", PaymentMethod = PaymentMethod.Cash, TransactionDate = DateTime.Now },
                new Transaction { TransactionId = 654, MemberID = 345, EmployeeID = 22, Amount = "100.00", PaymentMethod = PaymentMethod.Cash, TransactionDate = DateTime.Now }
                };
                foreach (Transaction s in Transactions)
                {
                    context.Transaction.Add(s);
                }
                context.SaveChanges();
            }
        }
    }

        