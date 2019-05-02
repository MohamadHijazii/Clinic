using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class DatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.dates.Include(d => d.patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dates = await _context.dates
                .Include(d => d.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dates == null)
            {
                return NotFound();
            }

            return View(dates);
        }

        // GET: Dates/Create
        public IActionResult Create()
        {
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "Id");
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,patient_id,date,time,name,alpha")] Dates dates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "Id", dates.patient_id);
            return View(dates);
        }

        // GET: Dates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dates = await _context.dates.FindAsync(id);
            if (dates == null)
            {
                return NotFound();
            }
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "Id", dates.patient_id);
            return View(dates);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,patient_id,date,time,name,alpha")] Dates dates)
        {
            if (id != dates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatesExists(dates.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "Id", dates.patient_id);
            return View(dates);
        }

        // GET: Dates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dates = await _context.dates
                .Include(d => d.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dates == null)
            {
                return NotFound();
            }

            return View(dates);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dates = await _context.dates.FindAsync(id);
            _context.dates.Remove(dates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatesExists(int id)
        {
            return _context.dates.Any(e => e.Id == id);
        }
    }
}
