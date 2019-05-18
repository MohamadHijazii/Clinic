using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Clinic.Controllers
{

    [Authorize]
    public class Reminder_adminController : Controller
    {
        private readonly ApplicationDbContext _context;


        private readonly UserManager<ApplicationUser> _userManager;

        public Reminder_adminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reminder_admin
        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            var applicationDbContext = _context.reminders.Where(q => q.UserID == userid);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reminder_admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.reminders
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminder_admin == null)
            {
                return NotFound();
            }

            return View(reminder_admin);
        }

        // GET: Reminder_admin/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Reminder_admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,date,content,title,time")] Reminder_admin reminder_admin)
        {
            if (ModelState.IsValid)
            {
                reminder_admin.UserID = _userManager.GetUserId(HttpContext.User);
                _context.Add(reminder_admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email", reminder_admin.UserID);
            return View(reminder_admin);
        }

        // GET: Reminder_admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.reminders.FindAsync(id);
            if (reminder_admin == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email", reminder_admin.UserID);
            return View(reminder_admin);
        }

        // POST: Reminder_admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,date,content,title,time,UserID")] Reminder_admin reminder_admin)
        {
            if (id != reminder_admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminder_admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Reminder_adminExists(reminder_admin.Id))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email", reminder_admin.UserID);
            return View(reminder_admin);
        }

        // GET: Reminder_admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder_admin = await _context.reminders
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminder_admin == null)
            {
                return NotFound();
            }

            return View(reminder_admin);
        }

        // POST: Reminder_admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reminder_admin = await _context.reminders.FindAsync(id);
            _context.reminders.Remove(reminder_admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Reminder_adminExists(int id)
        {
            return _context.reminders.Any(e => e.Id == id);
        }
    }
}
