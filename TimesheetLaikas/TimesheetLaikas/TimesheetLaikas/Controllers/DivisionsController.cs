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
    [Authorize(Roles = "Admin,HR")]
    public class DivisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Divisions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Division.Include(d => d.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Divisions/Details/5
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
        public IActionResult Create()
        {
            ViewData["DivsionChairId"] = new SelectList(_context.Employee, "Id", "FULL_NAME");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var division = await _context.Division.FindAsync(id);
            _context.Division.Remove(division);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisionExists(int id)
        {
            return _context.Division.Any(e => e.Id == id);
        }
    }
}