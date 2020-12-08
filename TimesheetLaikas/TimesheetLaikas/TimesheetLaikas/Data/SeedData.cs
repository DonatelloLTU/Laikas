// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="SeedData.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;

namespace TimesheetLaikas.Data
{
    /// <summary>
    /// Class SeedData.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Initialize(ApplicationDbContext context)
        {
        }

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public static async Task Initialize(ApplicationDbContext context,
                                     UserManager<Employee> userManager,
                                     RoleManager<Roles> roleManager)
        {
            context.Database.EnsureCreated();

            string adminId1 = "";
            //string HR = "";

            string Admin = "Admin";
            string HR = "HR";
            string RegularEmployee = "Regular Employee";
            string Faculty = "Faculty";
            string Supervisor = "Supervisor";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(Admin) == null)
            {
                var admin = new Roles

                {
                    Name = Admin,
                };

                await roleManager.CreateAsync(admin);
            }
            if (await roleManager.FindByNameAsync(RegularEmployee) == null)
            {
                var employee = new Roles

                {
                    Name = Faculty,
                };

                await roleManager.CreateAsync(employee);
            }

            if (await roleManager.FindByNameAsync(HR) == null)
            {
                var hr = new Roles

                {
                    Name = HR,
                };
                await roleManager.CreateAsync(hr);
            }

            if (await roleManager.FindByNameAsync(Supervisor) == null)
            {
                var supervisor = new Roles

                {
                    Name = Supervisor,
                };
                await roleManager.CreateAsync(supervisor);
            }

            if (await userManager.FindByNameAsync("root@admin.com") == null)
            {
                var user = new Employee
                {
                    UserName = "root@admin.com",
                    Email = "root@admin.com",
                    EMP_FNAME = "root",
                    EMP_LNAME = "admin",
                    ADDRESS = "123 Admin Way",
                    CITY = "Parkersburg",
                    ZIPCODE = "26105",
                    PhoneNumber = "6902341234",
                    Payrate = 0,
                    DepartmentId = 1,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, Admin);
                }
                Admin = user.Id;
            }

            if (await userManager.FindByNameAsync("hr@wvup.edu") == null)
            {
                var user = new Employee
                {
                    UserName = "hr@wvup.edu",
                    Email = "hr@wvup.edu",
                    EMP_FNAME = "Human",
                    EMP_LNAME = "Resources",
                    ADDRESS = "123 Campus",
                    CITY = "Parkersburg",
                    ZIPCODE = "26104",
                    PhoneNumber = "12300012345",
                    Payrate = 20.00M,
                    DepartmentId = 8,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, HR);
                }
                HR = user.Id;
            }
        }
    }
}