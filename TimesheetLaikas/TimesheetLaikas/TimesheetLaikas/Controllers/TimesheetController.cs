﻿// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 12-07-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="TimesheetController.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using TimesheetLaikas.Models.ViewModels;
using Serilog;
using Serilog.Sinks.SystemConsole;
using Serilog;
namespace TimesheetLaikas.Controllers
{
    /// <summary>
    /// Class TimesheetController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class TimesheetController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<Employee> _userManager;
        /// <summary>
        /// The role manager
        /// </summary>
        private readonly RoleManager<Roles> _roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesheetController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        public TimesheetController(ApplicationDbContext context, UserManager<Employee> userManager, RoleManager<Roles> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public TimesheetController()
        {
        }


        /// <summary>
        /// Indexes the specified sort order.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index(string sortOrder/*, string statusString*/)
        {
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var db = _context.Timesheet.Include(t => t.Employee);
            var timesheets = from t in _context.Timesheet
                             select t;


            switch (sortOrder)
            {
                case "name_desc":
                    timesheets = timesheets.OrderByDescending(t => t.Employee.EMP_LNAME);
                    break;

                case "Date":
                    timesheets = timesheets.OrderBy(t => t.PunchIn);
                    break;

                case "date_desc":
                    timesheets = timesheets.OrderByDescending(t => t.PunchIn);
                    break;
            }

            return View(await timesheets.AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Views the timesheets.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> ViewTimesheets()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var timesheets = from t in _context.Timesheet
                             where t.EmpID == currentUser.Id
                             select t;

            return View(await timesheets.AsNoTracking().ToListAsync());
        }


        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        /// <summary>
        /// Times the punch.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult TimePunch()
        {

            return View();
        }

        /// <summary>
        /// Punches the in.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PunchIn(TimesheetViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                Timesheet timesheet = new Timesheet();

                timesheet.PunchIn = DateTime.Now;
                
                timesheet.EmpID = currentUser.Id;


                _context.Add(timesheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }

        /// <summary>
        /// Punches the out.
        /// </summary>
        /// <param name="timesheet">The timesheet.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PunchOut(Timesheet timesheet)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                timesheet = this._context.Timesheet
                                .Where(c => c.EmpID == currentUser.Id)
                                .OrderByDescending(t => t.PunchIn)
                                .FirstOrDefault();


                timesheet.PunchOut = DateTime.Now;

                _context.Update(timesheet);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(timesheet);
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["EmpID"] = new SelectList(_context.Employee, "Id", "FULL_NAME");
            return View();
        }


        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimesheetViewModel model)
        {
            var statuses = new List<SelectListItem>();


            if (ModelState.IsValid)
            {
                Timesheet timesheet = new Timesheet();

                timesheet.PunchIn = model.PunchIn;
                timesheet.PunchOut = model.PunchOut;
           
                timesheet.EmpID = model.EmpID;

                if (model.PunchOut != null)
                {
                    DateTime ValidPunchOut = model.PunchOut.Value;

                    var user = _context.Employee.Find(model.EmpID);

                    TimeSpan difference = ValidPunchOut - model.PunchIn;
                    timesheet.TotalWorkTime = string.Format("{0:0}:{1:00}", difference.TotalHours, difference.Minutes);
                    decimal payrate = user.Payrate;
                    timesheet.TotalPay = payrate * difference.Hours;
                }



                _context.Add(timesheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmpID"] = new SelectList(_context.Employee, "Id", "FULL_NAME", model.EmpID);

            return View(model);
        }


        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            TimesheetViewModel model = new TimesheetViewModel();

            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet.FindAsync(id);

            if (id != null)
            {
                
                model.EmpID = timesheet.EmpID;
                model.PunchIn = timesheet.PunchIn;
                model.PunchOut = timesheet.PunchOut;
                model.TotalWorkTime = timesheet.TotalWorkTime;
                model.TotalPay = timesheet.TotalPay;
            }

            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }


        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="timesheet">The timesheet.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PunchIn,PunchOut,Status,EmpID,StatusComments,TotalWorkTime,Id,TimeStamp")] TimesheetViewModel timesheet)
        {
            if (ModelState.IsValid)
            {
                var timesheetEdit = await _context.Timesheet.FindAsync(id);

                if (timesheetEdit != null)
                {
                    
                    timesheetEdit.PunchIn = timesheet.PunchIn;
                    timesheetEdit.PunchOut = timesheet.PunchOut;
                    timesheetEdit.EmpID = timesheet.EmpID;
                   

                    if (timesheetEdit.PunchOut != null)
                    {
                        DateTime ValidPunchOut = timesheet.PunchOut.Value;

                        TimeSpan difference = ValidPunchOut - timesheetEdit.PunchIn;
                        timesheet.TotalWorkTime = string.Format("{0:0}:{1:00}", difference.TotalHours, difference.Minutes);
                    }
                    else
                    {

                    }
                }

                _context.Update(timesheetEdit);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpID"] = new SelectList(_context.Employee, "Id", "FULL_NAME", timesheet.EmpID);

            return View(timesheet);
        }


        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheet
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);
            _context.Timesheet.Remove(timesheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Timesheets the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool TimesheetExists(int id)
        {
            return _context.Timesheet.Any(e => e.Id == id);
        }
    }
}