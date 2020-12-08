using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee, Roles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

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


        public DbSet<Department> Department { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Payperiod> Payperiods { get; set; }
        public DbSet<Roles> EmployeeRoles { get; set; }
    }
}