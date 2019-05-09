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
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace Clinic.Controllers
{

    [Authorize]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<Patient> _logger;
        private readonly IEmailSender _emailSender;

        public PatientsController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<Patient> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [Authorize(Roles = "Admin,Doctor,Assistant")]
        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.patients.Include(p => p.insurance);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin,Doctor,Assistant")]
        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients
                .Include(p => p.insurance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [Authorize(Roles = "Admin,Doctor,Assistant")]
        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["insurance_id"] = new SelectList(_context.insurances, "Id", "name");

            var patient = new Patient();

            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };

            return View(patient);
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fname,mname,lname,username,pass,phone,mobile,email,display_name,gender,address,birthday,blood_type,insurance_id,token")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                var user2 = new ApplicationUser { UserName = patient.email, Email = patient.email, PhoneNumber = patient.mobile,fname=patient.fname,mname=patient.mname,lname=patient.lname};
                var result = await _userManager.CreateAsync(user2, "Test@123");

                if (result.Succeeded)
                {
                    _logger.LogInformation("Doctor created a new Patient with password.");
                    _context.Add(patient);

                    await _context.SaveChangesAsync();
                    await _userManager.AddToRoleAsync(user2, "Patient");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            
            ViewData["insurance_id"] = new SelectList(_context.insurances, "Id", "name", patient.insurance_id);

            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };
            return View(patient);
        }

        [Authorize(Roles = "Admin,Doctor,Assistant")]
        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients.FindAsync(id);


            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };

            if (patient == null)
            {
                return NotFound();
            }
            ViewData["insurance_id"] = new SelectList(_context.insurances, "Id", "name", patient.insurance_id);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fname,mname,lname,username,pass,phone,mobile,email,display_name,gender,address,birthday,blood_type,insurance_id,token")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            ViewData["insurance_id"] = new SelectList(_context.insurances, "Id", "name", patient.insurance_id);
            return View(patient);
        }

        [Authorize(Roles = "Admin,Doctor,Assistant")]
        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients
                .Include(p => p.insurance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.patients.FindAsync(id);

            var user = await _userManager.FindByEmailAsync(patient.email);


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



            _context.patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.patients.Any(e => e.Id == id);
        }
    }
}
