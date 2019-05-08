using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Clinic.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AssistantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<Assistant> _logger;
        private readonly IEmailSender _emailSender;


        public AssistantsController(
            ApplicationDbContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<Assistant> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        // GET: Assistants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.assistants.Include(a => a.doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assistants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.assistants
                .Include(a => a.doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // GET: Assistants/Create
        public IActionResult Create()
        {
            ViewData["ref_doctor"] = new SelectList(_context.doctors, "Id", "display_name");
            return View();
        }

        // POST: Assistants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fname,mname,lname,username,pass,phone,email,display_name,ref_doctor")] Assistant assistant)
        {
            if (ModelState.IsValid)
            {
                var user2 = new IdentityUser { UserName = assistant.email, Email = assistant.email,PhoneNumber= assistant.phone};
                var result = await _userManager.CreateAsync(user2, "Test@123");

                if (result.Succeeded)
                {
                    _logger.LogInformation("Admin created a new Assistant with password.");
                    _context.Add(assistant);

                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user2, "Assistant");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            ViewData["ref_doctor"] = new SelectList(_context.doctors, "Id", "display_name", assistant.ref_doctor);
            return View(assistant);
        }

        // GET: Assistants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.assistants.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }
            ViewData["ref_doctor"] = new SelectList(_context.doctors, "Id", "display_name", assistant.ref_doctor);
            return View(assistant);
        }

        // POST: Assistants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fname,mname,lname,username,phone,email,ref_doctor")] Assistant assistant)
        {
            if (id != assistant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistantExists(assistant.Id))
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
            ViewData["ref_doctor"] = new SelectList(_context.doctors, "Id", "display_name", assistant.ref_doctor);
            return View(assistant);
        }

        // GET: Assistants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistant = await _context.assistants
                .Include(a => a.doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistant == null)
            {
                return NotFound();
            }

            return View(assistant);
        }

        // POST: Assistants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistant = await _context.assistants.FindAsync(id);

            var user = await _userManager.FindByEmailAsync(assistant.email);


            var rolesForUser = await _userManager.GetRolesAsync(user);

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    // item should be the name of the role
                    var result = await _userManager.RemoveFromRoleAsync(user, item);
                }

                await _userManager.DeleteAsync(user);
            }

            _context.assistants.Remove(assistant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistantExists(int id)
        {
            return _context.assistants.Any(e => e.Id == id);
        }
    }
}
