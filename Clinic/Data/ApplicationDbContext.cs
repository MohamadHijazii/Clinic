using System;
using System.Collections.Generic;
using System.Text;
using Clinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Assistant> assistants { get; set; }
        public DbSet<Consultation> consultations { get; set; }
        public DbSet<Insurance> insurances { get; set; }
        public DbSet<Messages> messages { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Dates> dates { get; set; }
        public DbSet<List> lists { get; set; }
        public DbSet<Reminder_admin> reminders { get; set; }
        //public DbSet<Reminder_doctor> reminder_Doctors { get; set; }
        //public DbSet<Reminder_insurance> reminder_Insurances { get; set; }
        //public DbSet<Reminder_patient> reminder_Patients { get; set; }
        //public DbSet<Reminder_assistant> reminder_Assistants { get; set; }

    }
}
