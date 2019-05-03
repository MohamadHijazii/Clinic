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
    public class ConsultationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultationsController(ApplicationDbContext context)
        {
            _context = context;
        }

            public IActionResult test()
        {
         return View();
        }


        [HttpPost]
        public IActionResult testing(int put)
        {

            //var reports = _context.reports
            //    .Include(i => i.insurance)
            //    .Include(p => p.patient)
            //    .Include(d => d.doctor)
            //    .FirstOrDefault(d => d.insurance.Id == put);


            var consultations = _context.consultations
                .Include(p => p.patient)
                .Include(d => d.doctor);

           var patients = _context.patients
                .Include(c=> c.consultations)
                .Where(p => p.insurance_id == put).ToList();

            return View(patients);
        }



        // GET: Consultations
        public async Task<IActionResult> Index()
        {
            var clinicContext = _context.consultations.Include(c => c.doctor).Include(c => c.patient);
            return View(await clinicContext.ToListAsync());
        }


        // GET: Consultations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.consultations
                .Include(c => c.doctor)
                .Include(c => c.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // GET: Consultations/Create
        public IActionResult Create()
        {
            ViewData["doctor_id"] = new SelectList(_context.doctors, "Id", "fname");
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "fname");
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,patient_id,doctor_id,title,type,date,symptoms,diagnostics,temp,blood_presure,cost,treatment,insurance_conf")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {

                 _context.Add(consultation);

                //var reports = new Report();
                //reports.cost = consultation.cost;
                //reports.title = consultation.title;

                //var patient = _context.patients.FindAsync(consultation.patient_id);
                //var doctor = _context.doctors.FindAsync(consultation.doctor_id);


                //var insur = _context.insurances.FindAsync(patient.Result.insurance_id);

                //reports.insurance = await insur;
                //reports.doctor = await doctor;
                //reports.patient = await patient;
                //reports.date = consultation.date;
                //_context.reports.Add(reports);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["doctor_id"] = new SelectList(_context.doctors, "Id", "fname", consultation.doctor_id);
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "fname", consultation.patient_id);
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.consultations.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }
            ViewData["doctor_id"] = new SelectList(_context.doctors, "Id", "fname", consultation.doctor_id);
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "fname", consultation.patient_id);
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,patient_id,doctor_id,title,type,date,symptoms,diagnostics,temp,blood_presure,cost,treatment,insurance_conf")] Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(consultation.Id))
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
            ViewData["doctor_id"] = new SelectList(_context.doctors, "Id", "fname", consultation.doctor_id);
            ViewData["patient_id"] = new SelectList(_context.patients, "Id", "fname", consultation.patient_id);
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.consultations
                .Include(c => c.doctor)
                .Include(c => c.patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultation = await _context.consultations.FindAsync(id);
            _context.consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationExists(int id)
        {
            return _context.consultations.Any(e => e.Id == id);
        }
    }
}
