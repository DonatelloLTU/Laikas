using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SQLitePCL;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using TimesheetLaikas.Models.ViewModels;

namespace TimesheetLaikas.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> userManager;
        private readonly RoleManager<Roles> roleManager;
        private readonly ApplicationDbContext _context;

        public EmployeeController(UserManager<Employee> userManager, RoleManager<Roles> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["LNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
            ViewData["FNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewData["DepartmentParm"] = String.IsNullOrEmpty(sortOrder) ? "dept_desc" : "";
            var employees = from e in _context.Employee
                            select e;

            switch (sortOrder)
            {
                case "lname_desc":
                    employees = employees.OrderByDescending(e => e.EMP_LNAME);
                    break;

                case "fname_desc":
                    employees = employees.OrderByDescending(e => e.EMP_FNAME);
                    break;

                case "dept_desc":
                    employees = employees.OrderByDescending(e => e.Department.DeptName);
                    break;
            }

            return View(await employees.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public IActionResult AddUser()
        {


            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DeptName");
            return View("AddUser", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee user = new Employee
                {

                    EMP_FNAME = model.EMP_FNAME,
                    EMP_LNAME = model.EMP_LNAME,
                    Email = model.Email,
                    UserName = model.Email,
                    ADDRESS = model.ADDRESS,
                    CITY = model.CITY,
                    ZIPCODE = model.ZIPCODE,
                    Payrate = model.Payrate,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    PhoneNumber = model.EMP_PHONE,
                    DepartmentId = model.DepartmentId,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    Roles applicationRole = await roleManager.FindByIdAsync(model.RoleId);
                    if (applicationRole != null)
                    {
                        IdentityResult roleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DeptName", model.DepartmentId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                Employee user = await userManager.FindByIdAsync(id);
                if (user != null)
                {

                    model.EMP_FNAME = user.EMP_FNAME;
                    model.EMP_LNAME = user.EMP_LNAME;
                    model.Email = user.Email;
                    model.UserName = user.Email;
                    model.EMP_PHONE = user.PhoneNumber;
                    model.RoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                    model.ADDRESS = user.ADDRESS;
                    model.CITY = user.CITY;
                    model.ZIPCODE = user.ZIPCODE;
                    model.Payrate = user.Payrate;
                    model.Password = user.Password;
                    model.ConfirmPassword = user.ConfirmPassword;
                    model.DepartmentId = user.DepartmentId;
                }
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DeptName", model.DepartmentId);
            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee user = await userManager.FindByIdAsync(id);
                if (user != null)
                {

                    user.EMP_FNAME = model.EMP_FNAME;
                    user.Email = model.Email;
                    user.EMP_LNAME = model.EMP_LNAME;
                    user.UserName = model.Email;
                    user.PhoneNumber = model.EMP_PHONE;
                    user.ADDRESS = model.ADDRESS;
                    user.CITY = model.CITY;
                    user.DepartmentId = model.DepartmentId;
                    user.ZIPCODE = model.ZIPCODE;
                    user.Payrate = model.Payrate;

                    string existingRole = userManager.GetRolesAsync(user).Result.Single();
                    string existingRoleId = roleManager.Roles.Single(r => r.Name == existingRole).Id;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (existingRoleId != model.RoleId)
                        {
                            IdentityResult roleResult = await userManager.RemoveFromRoleAsync(user, existingRole);
                            if (roleResult.Succeeded)
                            {
                                Roles applicationRole = await roleManager.FindByIdAsync(model.RoleId);
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await userManager.AddToRoleAsync(user, applicationRole.Name);
                                    if (newRoleResult.Succeeded)
                                    {
                                        return RedirectToAction("Index");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DeptName", model.DepartmentId);
            return View(model);
        }
    }
}