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
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Clinic.Controllers
{

    [Authorize(Roles ="Admin")]
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;



        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<Doctor> _logger;
        private readonly IEmailSender _emailSender;


        public DoctorsController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<Doctor> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {

            var doctor = new Doctor();

            var specialty = new List<SelectListItem>
        {
                new SelectListItem {Value="Cardiologist",Text="Cardiologist"},
                new SelectListItem {Value="Surgeon",Text="Surgeon"},
                new SelectListItem {Value="Psychiatrist",Text="Psychiatrist"},
                new SelectListItem {Value="Dermatologist",Text="Dermatologist"},
                new SelectListItem {Value="Nephrologist",Text="Nephrologist"},
                new SelectListItem {Value="Ophthalmologist",Text="Ophthalmologist"},
                new SelectListItem {Value="Otolaryngologist",Text="Otolaryngologist"},
                new SelectListItem {Value="Neurologist",Text="Neurologist"},
                new SelectListItem {Value="Radiologist",Text="Radiologist"}
        };

            doctor.Items = specialty;

            return View(doctor);
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fname,mname,lname,username,pass,phone,mobile,email,display_name,gender,speciality,time,address,about")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var user2 = new ApplicationUser { UserName = doctor.email, Email = doctor.email,PhoneNumber=doctor.mobile,fname=doctor.fname,mname= doctor.mname,lname=doctor.lname};
                var result = await _userManager.CreateAsync(user2, "Test@123");

                if (result.Succeeded)
                {
                    _logger.LogInformation("Admin created a new Doctor with password.");
                    _context.Add(doctor);
                    await _userManager.AddToRoleAsync(user2, "Doctor");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var specialty = new List<SelectListItem>
        {
                new SelectListItem {Value="Cardiologist",Text="Cardiologist"},
                new SelectListItem {Value="Surgeon",Text="Surgeon"},
                new SelectListItem {Value="Psychiatrist",Text="Psychiatrist"},
                new SelectListItem {Value="Dermatologist",Text="Dermatologist"},
                new SelectListItem {Value="Nephrologist",Text="Nephrologist"},
                new SelectListItem {Value="Ophthalmologist",Text="Ophthalmologist"},
                new SelectListItem {Value="Otolaryngologist",Text="Otolaryngologist"},
                new SelectListItem {Value="Neurologist",Text="Neurologist"},
                new SelectListItem {Value="Radiologist",Text="Radiologist"}
        };

            doctor.Items = specialty;

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = new List<SelectListItem>
        {
                new SelectListItem {Value="Cardiologist",Text="Cardiologist"},
                new SelectListItem {Value="Surgeon",Text="Surgeon"},
                new SelectListItem {Value="Psychiatrist",Text="Psychiatrist"},
                new SelectListItem {Value="Dermatologist",Text="Dermatologist"},
                new SelectListItem {Value="Nephrologist",Text="Nephrologist"},
                new SelectListItem {Value="Ophthalmologist",Text="Ophthalmologist"},
                new SelectListItem {Value="Otolaryngologist",Text="Otolaryngologist"},
                new SelectListItem {Value="Neurologist",Text="Neurologist"},
                new SelectListItem {Value="Radiologist",Text="Radiologist"}
        };


            var doctor = await _context.doctors.FindAsync(id);

            doctor.Items = specialty;

            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fname,mname,lname,username,pass,phone,mobile,email,display_name,gender,speciality,time,address,about")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.doctors.FindAsync(id);

            var user = await _userManager.FindByEmailAsync(doctor.email);


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

            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.doctors.Any(e => e.Id == id);
        }


        //[HttpGet]
        //public string GeneratePassword()
        //{
        //    var options = _userManager.Options.Password;

        //    int length = options.RequiredLength;

        //    bool nonAlphanumeric = options.RequireNonAlphanumeric;
        //    bool digit = options.RequireDigit;
        //    bool lowercase = options.RequireLowercase;
        //    bool uppercase = options.RequireUppercase;

        //    StringBuilder password = new StringBuilder();
        //    Random random = new Random();

        //    while (password.Length < length)
        //    {
        //        char c = (char)random.Next(32, 126);

        //        password.Append(c);

        //        if (char.IsDigit(c))
        //            digit = false;
        //        else if (char.IsLower(c))
        //            lowercase = false;
        //        else if (char.IsUpper(c))
        //            uppercase = false;
        //        else if (!char.IsLetterOrDigit(c))
        //            nonAlphanumeric = false;
        //    }

        //    if (nonAlphanumeric)
        //        password.Append((char)random.Next(33, 48));
        //    if (digit)
        //        password.Append((char)random.Next(48, 58));
        //    if (lowercase)
        //        password.Append((char)random.Next(97, 123));
        //    if (uppercase)
        //        password.Append((char)random.Next(65, 91));

        //    return password.ToString();
        //}

    }
}
