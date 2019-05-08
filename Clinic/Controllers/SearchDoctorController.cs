using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Authorize(Roles = "Patient")]

    public class SearchDoctorController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public SearchDoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Search(string searchString)
        {
            var doctor = from c in _context.doctors
                                select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["find"] = 1;
               doctor = doctor.Where(s => s.fname == searchString);

                if (doctor.Count() < 1)
                {
                    ViewData["find"] = 0;
                }
            }
            else
            {
                ViewData["find"] = -1;
            }


            return View(await doctor.ToListAsync());
        }


    }
}