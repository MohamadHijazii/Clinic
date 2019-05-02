using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Data.SeededData
{
    public class PatientData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.patients.Any())
                {
                    return;   // DB has been seeded
                }

                context.patients.AddRange(

                    new Patient
                    {
                        fname = "Mohammad",
                        mname = "Ali",
                        lname = "Outa",
                        username = "MAO",
                        pass = "MAO@123",
                        phone = "79194353",
                        email = "Mohammad_Kouta@gmail.com",
                        gender = "Male",
                        address = "Trablos",
                        birthday= new DateTime(1999,4,30),
                        blood_type="A+",
                        insurance=2
                    },

                       new Patient
                       {
                           fname = "Mohammad",
                           mname = "Hassan",
                           lname = "Naji",
                           username = "Nojje",
                           pass = "nojje@123",
                           phone = "76438085",
                           email = "Mohammad_Naji@gmail.com",
                           gender = "Male",
                           address = "Aynata",
                           birthday = new DateTime(1999, 1, 1),
                           blood_type = "A+",
                           insurance = 2
                       },

                          new Patient
                          {
                              fname = "Mortada",
                              mname = "Wassim",
                              lname = "Ghanem",
                              username = "MG",
                              pass = "MG@123",
                              phone = "79130115",
                              email = "virus@live.com",
                              gender = "Male",
                              address = "Aynata",
                              birthday = new DateTime(1997, 10, 30),
                              blood_type = "O+",
                              insurance = 3
                          }



                );
                context.SaveChanges();
            }
        }



    }
}
