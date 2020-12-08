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