﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewLynn_GymDb.Areas.Identity.Data;

#nullable disable

namespace NewLynn_GymDb.Migrations
{
    [DbContext(typeof(NewLynn_GymDbContext))]
    partial class NewLynn_GymDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MemberTransaction", b =>
                {
                    b.Property<int>("MembersMemberId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionsTransactionId")
                        .HasColumnType("int");

                    b.HasKey("MembersMemberId", "TransactionsTransactionId");

                    b.HasIndex("TransactionsTransactionId");

                    b.ToTable("MemberTransaction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Attendence", b =>
                {
                    b.Property<int>("AttendenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendenceID"), 1L, 1);

                    b.Property<DateTime>("AttendenceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendenceID");

                    b.ToTable("Attendance", (string)null);

                    b.HasData(
                        new
                        {
                            AttendenceID = 123,
                            AttendenceDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1633),
                            EmployeeID = 12,
                            MemberID = 12,
                            Status = "Present"
                        },
                        new
                        {
                            AttendenceID = 321,
                            AttendenceDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1677),
                            EmployeeID = 5,
                            MemberID = 123,
                            Status = "Absent"
                        },
                        new
                        {
                            AttendenceID = 576,
                            AttendenceDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1681),
                            EmployeeID = 22,
                            MemberID = 345,
                            Status = "Absent"
                        });
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AttendenceID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AttendenceID");

                    b.HasIndex("TransactionId");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            EmployeeId = 12,
                            Address = "1603 Great South Road",
                            Email = "ac7egc33@gmail.com",
                            FirstName = "Sarah",
                            HireDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1871),
                            LastName = "Dawon",
                            PhoneNumber = "0223583943",
                            Position = "Manager",
                            Salary = "$27.50/Hr"
                        },
                        new
                        {
                            EmployeeId = 5,
                            Address = "1634 Great North Road",
                            Email = "wfuw3hf@gmail.com",
                            FirstName = "Ranav",
                            HireDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1877),
                            LastName = "Singh",
                            PhoneNumber = "022383968",
                            Position = "Front Desk",
                            Salary = "$27.50/Hr"
                        },
                        new
                        {
                            EmployeeId = 22,
                            Address = "1603 Great South Road",
                            Email = "ac7egc33@gmail.com",
                            FirstName = "Sarah",
                            HireDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1881),
                            LastName = "Dawon",
                            PhoneNumber = "0223583943",
                            Position = "Manager",
                            Salary = "$27.50/Hr"
                        });
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AttendenceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MembershipType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.HasIndex("AttendenceID");

                    b.ToTable("Member", (string)null);

                    b.HasData(
                        new
                        {
                            MemberId = 12,
                            Address = "1603 Great South Road",
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987),
                            Email = "ac7egc33@gmail.com",
                            FirstName = "Sarah",
                            JoinDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1986),
                            LastName = "Dawon",
                            MembershipType = "Monthly",
                            PaymentInformation = "4929 1234 5678 9012",
                            PhoneNumber = "0223583943"
                        },
                        new
                        {
                            MemberId = 123,
                            Address = "1603 Great South Road",
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987),
                            Email = "ac7egc33@gmail.com",
                            FirstName = "Sarah",
                            JoinDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1991),
                            LastName = "Dawon",
                            MembershipType = "Monthly",
                            PaymentInformation = "4929 1234 5678 9012",
                            PhoneNumber = "0223583943"
                        },
                        new
                        {
                            MemberId = 345,
                            Address = "1603 Great South Road",
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987),
                            Email = "ac7egc33@gmail.com",
                            FirstName = "Sarah",
                            JoinDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(1995),
                            LastName = "Dawon",
                            MembershipType = "Monthly",
                            PaymentInformation = "4929 1234 5678 9012",
                            PhoneNumber = "0223583943"
                        });
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction", (string)null);

                    b.HasData(
                        new
                        {
                            TransactionId = 321,
                            Amount = "100.00",
                            EmployeeID = 12,
                            MemberID = 12,
                            PaymentMethod = "Credit Card",
                            TransactionDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(2053)
                        },
                        new
                        {
                            TransactionId = 987,
                            Amount = "100.00",
                            EmployeeID = 5,
                            MemberID = 123,
                            PaymentMethod = "Credit Card",
                            TransactionDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(2057)
                        },
                        new
                        {
                            TransactionId = 654,
                            Amount = "100.00",
                            EmployeeID = 22,
                            MemberID = 345,
                            PaymentMethod = "Credit Card",
                            TransactionDate = new DateTime(2024, 5, 2, 14, 3, 15, 904, DateTimeKind.Local).AddTicks(2060)
                        });
                });

            modelBuilder.Entity("MemberTransaction", b =>
                {
                    b.HasOne("NewLynn_GymDb.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewLynn_GymDb.Models.Transaction", null)
                        .WithMany()
                        .HasForeignKey("TransactionsTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Employee", b =>
                {
                    b.HasOne("NewLynn_GymDb.Models.Attendence", null)
                        .WithMany("Employees")
                        .HasForeignKey("AttendenceID");

                    b.HasOne("NewLynn_GymDb.Models.Transaction", null)
                        .WithMany("Employees")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Member", b =>
                {
                    b.HasOne("NewLynn_GymDb.Models.Attendence", null)
                        .WithMany("Members")
                        .HasForeignKey("AttendenceID");
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Attendence", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("NewLynn_GymDb.Models.Transaction", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
