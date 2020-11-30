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

            modelBuilder.Entity<College>().HasData(
                         new College
                         {
                             Id = 1,
                             College_Name = "Default College Name",
                             State = States.WestVirginia
                         }

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
                b.ToTable("Employees");
            });

            modelBuilder.Entity<Employee>()
                .Property(i => i.Payrate)
                 .HasColumnType("Money");

            modelBuilder.Entity<Roles>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<Timesheet>()
                .Property(i => i.TotalPay)
                 .HasColumnType("Money");

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees);


            modelBuilder.Entity<Payperiod>()
                .HasMany(c => c.TimeSheetsForPayPeriod)
                .WithOne();

         
            modelBuilder.Entity<Timesheet>()
           .Property(c => c.Status)
           .HasConversion<string>();

            modelBuilder.Entity<Roles>()
           .Property(c => c.PayPeriodDuration)
           .HasConversion<string>();
        }

        
        public DbSet<Department> Department { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<Leave> Leave { get; set; }

  
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Payperiod> Payperiods { get; set; }


   
    }
}