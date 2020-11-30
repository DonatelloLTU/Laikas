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
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
        }

        public static async Task Initialize(ApplicationDbContext context,
                                     UserManager<Employee> userManager,
                                     RoleManager<Roles> roleManager)
        {
            context.Database.EnsureCreated();

            string adminId1 = "";
            //string HR = "";

            string Admin = "Admin";
            string HR = "HR";
            string STEMProfessor = "STEM Professor";
            string Faculty = "Faculty";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(Admin) == null)
            {
                var admin = new Roles

                {
                    Name = Admin,

                    DepartmentId = 1,
                };

                await roleManager.CreateAsync(admin);
            }
            if (await roleManager.FindByNameAsync(STEMProfessor) == null)
            {
                var stemprofessor = new Roles

                {
                    Name = STEMProfessor,
                    DepartmentId = 2,
                };

                await roleManager.CreateAsync(stemprofessor);
            }

            if (await roleManager.FindByNameAsync(HR) == null)
            {
                var hr = new Roles

                {
                    Name = HR,
                    DepartmentId = 9,
                };
                await roleManager.CreateAsync(hr);
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
                    State = States.WestVirginia,
                    EMP_PHONE = "6902341234",
                    Payrate = 0,
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, Admin);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("hr@wvup.edu") == null)
            {
                var user = new Employee
                {
                    UserName = "hr@wvup.edu",
                    Email = "hr@wvup.edu",
                    EMP_FNAME = "John",
                    EMP_LNAME = "Doe",
                    ADDRESS = "300 Campus Drive",
                    CITY = "Parkersburg",
                    ZIPCODE = "26105",
                    State = States.WestVirginia,
                    EMP_PHONE = "3044248000",
                    Payrate = 20.00M,
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