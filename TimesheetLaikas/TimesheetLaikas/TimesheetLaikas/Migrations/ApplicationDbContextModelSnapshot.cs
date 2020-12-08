﻿// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-07-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="ApplicationDbContextModelSnapshot.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimesheetLaikas.Data;

namespace TimesheetLaikas.Migrations
{
    /// <summary>
    /// Class ApplicationDbContextModelSnapshot.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Builds the model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("DivisionId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Department", "College");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeptName = "Admin",
                            DivisionId = 1
                        },
                        new
                        {
                            Id = 2,
                            DeptName = "Computer Science",
                            DivisionId = 2
                        },
                        new
                        {
                            Id = 3,
                            DeptName = "Computer Information Technology",
                            DivisionId = 2
                        },
                        new
                        {
                            Id = 4,
                            DeptName = "Mathematics",
                            DivisionId = 2
                        },
                        new
                        {
                            Id = 5,
                            DeptName = "Communication Studies",
                            DivisionId = 7
                        },
                        new
                        {
                            Id = 6,
                            DeptName = "Nursing",
                            DivisionId = 6
                        },
                        new
                        {
                            Id = 7,
                            DeptName = "Welding",
                            DivisionId = 2
                        },
                        new
                        {
                            Id = 8,
                            DeptName = "Human Resources",
                            DivisionId = 9
                        },
                        new
                        {
                            Id = 9,
                            DeptName = "Janitorial",
                            DivisionId = 10
                        },
                        new
                        {
                            Id = 10,
                            DeptName = "Faculty",
                            DivisionId = 10
                        });
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DivsionChairId")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("DivsionChairId");

                    b.ToTable("Division");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DivisionName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            DivisionName = "STEM"
                        },
                        new
                        {
                            Id = 3,
                            DivisionName = "Art Department"
                        },
                        new
                        {
                            Id = 4,
                            DivisionName = "Business, Account, and Public Service"
                        },
                        new
                        {
                            Id = 5,
                            DivisionName = "Education"
                        },
                        new
                        {
                            Id = 6,
                            DivisionName = "Health Sciences Division"
                        },
                        new
                        {
                            Id = 7,
                            DivisionName = "Humanities, Fine Arts, and Social Services"
                        },
                        new
                        {
                            Id = 8,
                            DivisionName = "Campus Security"
                        },
                        new
                        {
                            Id = 9,
                            DivisionName = "Human Resources"
                        },
                        new
                        {
                            Id = 10,
                            DivisionName = "General Staff"
                        });
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ADDRESS")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CITY")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EMP_FNAME")
                        .HasColumnType("TEXT");

                    b.Property<string>("EMP_LNAME")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Payrate")
                        .HasColumnType("Money");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("ZIPCODE")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Payperiod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmpID")
                        .HasColumnType("TEXT");

                    b.Property<double?>("OverTimeWorked")
                        .HasColumnType("REAL");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<double>("TotalHoursWorked")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("EmpID");

                    b.ToTable("Payperiods");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmpID")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PayperiodId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PunchIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PunchOut")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<decimal?>("TotalPay")
                        .HasColumnType("Money");

                    b.Property<string>("TotalWorkTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmpID");

                    b.HasIndex("PayperiodId");

                    b.ToTable("Timesheet", "Pay");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TimesheetLaikas.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Department", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Division", "Division")
                        .WithMany("Departments")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Division", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("DivsionChairId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Employee", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Department", "Department")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Payperiod", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpID");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Timesheet", b =>
                {
                    b.HasOne("TimesheetLaikas.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpID");

                    b.HasOne("TimesheetLaikas.Models.Payperiod", null)
                        .WithMany("TimeSheetsForPayPeriod")
                        .HasForeignKey("PayperiodId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Department", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Division", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("TimesheetLaikas.Models.Payperiod", b =>
                {
                    b.Navigation("TimeSheetsForPayPeriod");
                });
#pragma warning restore 612, 618
        }
    }
}
