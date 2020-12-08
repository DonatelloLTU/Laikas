// ***********************************************************************
// Assembly         : TimesheetLaikas
// Author           : Donatas & Matt
// Created          : 11-30-2020
//
// Last Modified By : Donatas & Matt
// Last Modified On : 12-07-2020
// ***********************************************************************
// <copyright file="DivisionsController.cs" company="TimesheetLaikas">
//     Copyright (c) HP Inc.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimesheetLaikas.Data;
using TimesheetLaikas.Models;
using TimesheetLaikas.Models.ViewModels;

namespace TimesheetLaikas.Controllers
{
    /// <summary>
    /// Class DivisionsController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Controller" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize(Roles = "Admin,HR")]
    public class DivisionsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Divisions
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Division.Include(d => d.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Divisions/Details/5
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

            var division = await _context.Division
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // GET: Divisions/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["DivsionChairId"] = new SelectList(_context.Employee, "Id", "FULL_NAME");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified division.
        /// </summary>
        /// <param name="division">The division.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisionName,DivsionChairId,Id,TimeStamp")] Division division)
        {
            if (ModelState.IsValid)
            {
                _context.Add(division);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivsionChairId"] = new SelectList(_context.Employee, "Id", "FULL_NAME", division.DivsionChairId);
            return View(division);
        }

        // GET: Divisions/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            DivisionViewModel model = new DivisionViewModel();

            if (id == null)
            {
                return NotFound();
            }
            var division = await _context.Division.FindAsync(id);
            if (id != null)
            {
                model.DivisionName = division.DivisionName;
                model.DivsionChairId = division.DivsionChairId;
            }

            if (division == null)
            {
                return NotFound();
            }
            ViewData["DivsionChairId"] = new SelectList(_context.Employee, "Id", "FULL_NAME", division.DivsionChairId);
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="division">The division.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DivisionViewModel division)
        {
            if (ModelState.IsValid)
            {
                var divisionEdit = await _context.Division.FindAsync(id);

                if (divisionEdit != null)
                {
                    divisionEdit.DivisionName = division.DivisionName;
                    divisionEdit.DivsionChairId = division.DivsionChairId;
                }

                _context.Update(divisionEdit);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["DivsionChairId"] = new SelectList(_context.Employee, "Id", "FULL_NAME", division.DivsionChairId);
            return View(division);
        }

        // GET: Divisions/Delete/5
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

            var division = await _context.Division
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // POST: Divisions/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var division = await _context.Division.FindAsync(id);
            _context.Division.Remove(division);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Divisions the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool DivisionExists(int id)
        {
            return _context.Division.Any(e => e.Id == id);
        }
    }
}