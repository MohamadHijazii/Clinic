using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Data.SeededData
{
    public class AssistantData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.assistants.Any())
                {
                    return;   // DB has been seeded
                }

                context.assistants.AddRange(
                    new Assistant
                    {
                        fname = "Ali",
                        mname = "Hassan",
                        lname = "l Haj Hassan",
                        username = "Alloush",
                        pass = "Alloush@123",
                        phone = "01345432",
                        email = "Alloush@rasoul.com",
                       ref_doctor=1
                    },

                      new Assistant
                      {
                          fname = "Hassan",
                          mname = "Hassan",
                          lname = "l Haj Hassan",
                          username = "Hassan",
                          pass = "Hassan@123",
                          phone = "123455432",
                          email = "Hassan@rasoul.com",
                          ref_doctor = 2
                      },

                        new Assistant
                        {
                            fname = "Mark",
                            mname = "Hassan",
                            lname = "l Haj Hassan",
                            username = "Mark",
                            pass = "Mark@123",
                            phone = "2332232",
                            email = "Mark@rasoul.com",
                            ref_doctor = 1
                        }





                );
                context.SaveChanges();
            }
        }



    }
}
