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

namespace Clinic.Controllers
{

    [Authorize(Roles = "Admin")]
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<Insurance> _logger;


        public InsurancesController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<Insurance> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        // GET: Insurances
        public async Task<IActionResult> Index()
        {
            return View(await _context.insurances.ToListAsync());
        }

        // GET: Insurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.insurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        // GET: Insurances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,email,phone,username,pass,address,fax")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                var user2 = new ApplicationUser { UserName = insurance.email, Email = insurance.email, PhoneNumber = insurance.phone, fname = insurance.name};
                var result = await _userManager.CreateAsync(user2, "Test@123");

                if (result.Succeeded)
                {
                    _logger.LogInformation("Admin created a new Insurance with password.");
                    _context.Add(insurance);

                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user2, "Insurance");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(insurance);
        }

        // GET: Insurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var insurance = await _context.insurances.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }
            return View(insurance);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,email,phone,username,pass,address,fax")] Insurance insurance)
        {
            if (id != insurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceExists(insurance.Id))
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
            return View(insurance);
        }

        // GET: Insurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insurance = await _context.insurances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insurance = await _context.insurances.FindAsync(id);

            var user = await _userManager.FindByEmailAsync(insurance.email);


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

            _context.insurances.Remove(insurance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceExists(int id)
        {
            return _context.insurances.Any(e => e.Id == id);
        }
    }
}
