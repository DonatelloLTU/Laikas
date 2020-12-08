// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="RolesController.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using TimesheetLaikas.Models.ViewModels;

namespace TimesheetLaikas.Controllers
{
    /// <summary>
    /// Class RolesController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize(Roles = "Admin,HR")]
    public class RolesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// The role manager
        /// </summary>
        private readonly RoleManager<Roles> _roleManager;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Employee> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="roleMgr">The role MGR.</param>
        /// <param name="userMrg">The user MRG.</param>
        /// <param name="context">The context.</param>
        public RolesController(RoleManager<Roles> roleMgr, UserManager<Employee> userMrg, ApplicationDbContext context)
        {
            _context = context;
            _roleManager = roleMgr;
            _userManager = userMrg;
        }

        // GET: Roles
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeRoles.ToListAsync());
        }

        // GET: Roles
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> GetEmployees(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);

            var users = new List<Employee>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    users.Add(user);
                }
            }

            RoleEmployeeList rm = new RoleEmployeeList();
            rm.EmployeesWithRole = users;

            if (!rm.EmployeesWithRole.Any())
            {
                return RedirectToAction("Index");
            }
            //To DO: Fix error when list is null

            return View(rm);
        }

        // GET: Roles/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Required] string id, RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id);
                Roles applicationRole = isExist ? await _roleManager.FindByIdAsync(id) :
                 new Roles
                 {
                 };
                applicationRole.Id = model.Id;
                applicationRole.Name = model.RoleName;

                //applicationRole.PayPeriodDuration = model.PayPeriodDuration;

                IdentityResult roleRuslt = isExist ? await _roleManager.UpdateAsync(applicationRole)
                                                    : await _roleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        // GET: Roles/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Edit(string id)
        {
            RoleViewModel model = new RoleViewModel();
            if (id == null)
            {
                return NotFound();
            }

            //var role = await _context.Roles.FindAsync(id);
            //var role = await _context.EmployeeRoles.FindAsync(id);

            Roles role = await _roleManager.FindByIdAsync(id);

            if (id != null)
            {
                model.RoleName = role.Name;

                // model.PayPeriodDuration = role.PayPeriodDuration;
            }

            if (role == null)
            {
                return NotFound();
            }

            return View("Edit", model);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RoleViewModel roles)
        {
            if (id != roles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var roleEdit = await _roleManager.FindByIdAsync(id);

                if (roleEdit != null)
                {
                    roleEdit.Name = roles.RoleName;

                    // roleEdit.PayPeriodDuration = roles.PayPeriodDuration;
                }

                IdentityResult result = await _roleManager.UpdateAsync(roleEdit);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                //_context.Update(roleEdit);
                //await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
            }

            return View(roles);
        }

        // GET: Roles/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = await _context.EmployeeRoles

                .FirstOrDefaultAsync(m => m.Id == id);
            if (roles == null)
            {
                return NotFound();
            }

            return View(roles);
        }

        // POST: Roles/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roles = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Roleses the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool RolesExists(string id)
        {
            return _context.EmployeeRoles.Any(e => e.Id == id);
        }

        /// <summary>
        /// Errorses the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}