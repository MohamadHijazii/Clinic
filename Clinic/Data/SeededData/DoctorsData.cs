using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Data.SeededData
{
    public class DoctorsData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.doctors.Any())
                {
                    return;   // DB has been seeded
                }

                context.doctors.AddRange(
                    new Doctor
                    {
                        fname = "Mohammad",
                        mname = "Hassan",
                        lname = "Hijazi",
                        username = "moudi",
                        pass="pass123",
                        mobile="03820357",
                        phone="01345432",
                        email="Mohammad_hijazi@rasoul.com",
                        gender="Male",
                        speciality="Digestive System",
                        time = "10 AM - 1 PM And 3 PM - 6 PM",
                        address="7ad l ka2im",
                        about="Love his job"
                    },

                    new Doctor
                    {
                        fname = "Hassan",
                        mname = "Sultan",
                        lname = "Assaad",
                        username = "kardon",
                        pass = "pass123",
                        mobile = "76938160",
                        phone = "05463205",
                        email = "hassanassaad15@rasoul.com",
                        gender = "Male",
                        speciality = "Cardiac",
                        time = "8 AM - 4 PM",
                        address = "7ad l mojtaba",
                        about = "Fantastic at work"
                    },

                    new Doctor
                    {
                        fname = "Hadi",
                        mname = "Ali",
                        lname = "Saleh",
                        username = "hodhod",
                        pass = "pass123",
                        mobile = "03051763",
                        phone = "05678988",
                        email = "hadi_saleh@rasoul.com",
                        gender = "Male",
                        speciality = "Dentist",
                        time = "1 PM - 6 PM",
                        address = "7ad Mojamma3 sayyed l chohada",
                        about = "Best person at his work"
                    }

                );
                context.SaveChanges();
            }
        }




    }
}
