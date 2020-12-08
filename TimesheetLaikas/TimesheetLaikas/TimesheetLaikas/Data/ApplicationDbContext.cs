// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Data
{
    /// <summary>
    /// Class ApplicationDbContext.
    /// Implements the <see cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{TimesheetLaikas.Models.Employee, TimesheetLaikas.Models.Roles, System.String}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{TimesheetLaikas.Models.Employee, TimesheetLaikas.Models.Roles, System.String}" />
    public class ApplicationDbContext : IdentityDbContext<Employee, Roles, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Division>().HasData(

               new Division { Id = 1, DivisionName = "Admin" },
               new Division { Id = 2, DivisionName = "STEM" },
               new Division { Id = 3, DivisionName = "Art Department" },
               new Division { Id = 4, DivisionName = "Business, Account, and Public Service" },
               new Division { Id = 5, DivisionName = "Education" },
               new Division { Id = 6, DivisionName = "Health Sciences Division" },
               new Division { Id = 7, DivisionName = "Humanities, Fine Arts, and Social Services" },
               new Division { Id = 8, DivisionName = "Campus Security" },
               new Division { Id = 9, DivisionName = "Human Resources" },
               new Division { Id = 10, DivisionName = "General Staff" }
         );

            modelBuilder.Entity<Department>()
          .HasData(
          new Department { Id = 1, DeptName = "Admin", DivisionId = 1 },
          new Department { Id = 2, DeptName = "Computer Science", DivisionId = 2 },
          new Department { Id = 3, DeptName = "Computer Information Technology", DivisionId = 2 },
          new Department { Id = 4, DeptName = "Mathematics", DivisionId = 2 },
          new Department { Id = 5, DeptName = "Communication Studies", DivisionId = 7 },
          new Department { Id = 6, DeptName = "Nursing", DivisionId = 6 },
          new Department { Id = 7, DeptName = "Welding", DivisionId = 2 },
          new Department { Id = 8, DeptName = "Human Resources", DivisionId = 9 },
          new Department { Id = 9, DeptName = "Janitorial", DivisionId = 10 },
          new Department { Id = 10, DeptName = "Faculty", DivisionId = 10 }

          );

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employee");
            });

            modelBuilder.Entity<Employee>()
                .Property(i => i.Payrate)
                 .HasColumnType("Money");

            modelBuilder.Entity<Roles>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<Timesheet>()
           .Property(c => c.Status)
           .HasConversion<string>();

            modelBuilder.Entity<Timesheet>()
                .Property(i => i.TotalPay)
                 .HasColumnType("Money");

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee);

            modelBuilder.Entity<Division>()
                .HasMany(d => d.Departments)
                .WithOne(e => e.Division);

            modelBuilder.Entity<Payperiod>()
                .HasMany(c => c.TimeSheetsForPayPeriod)
                .WithOne();
            ;



           // modelBuilder.Entity<Roles>()
           //.Property(c => c.PayPeriodDuration)
           //.HasConversion<string>();
        }


        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public DbSet<Department> Department { get; set; }
        /// <summary>
        /// Gets or sets the division.
        /// </summary>
        /// <value>The division.</value>
        public DbSet<Division> Division { get; set; }
        /// <summary>
        /// Gets or sets the timesheet.
        /// </summary>
        /// <value>The timesheet.</value>
        public DbSet<Timesheet> Timesheet { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>The employee.</value>
        public DbSet<Employee> Employee { get; set; }
        /// <summary>
        /// Gets or sets the payperiods.
        /// </summary>
        /// <value>The payperiods.</value>
        public DbSet<Payperiod> Payperiods { get; set; }
        /// <summary>
        /// Gets or sets the employee roles.
        /// </summary>
        /// <value>The employee roles.</value>
        public DbSet<Roles> EmployeeRoles { get; set; }
        public object Timesheets { get; set; }
    }
}