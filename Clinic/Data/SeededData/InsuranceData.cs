using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Data.SeededData
{
    public class InsuranceData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.insurances.Any())
                {
                    return;   // DB has been seeded
                }

                context.insurances.AddRange(
                    new Insurance
                    {
                        name = "Bsyncro",
                        email= "bsyncro@gmail.com",
                        phone="71245996",
                        username="Bsyncro",
                        pass="Bsyncro@123",
                        address="Shmel"
                    },

                     new Insurance
                     {
                         name = "B&I",
                         email = "BI@gmail.com",
                         phone = "70781215",
                         username = "b&i",
                         pass = "b&i@123",
                         address = "hamraa - 7ad SGBL Bank"
                     },

                    new Insurance
                    {
                        name = "Insurance Care",
                        email = "IC@gmail.com",
                        phone = "03163462",
                        username = "IC",
                        pass = "IC@123",
                        address = "Lebanon"
                    }

                );
                context.SaveChanges();
            }
        }







    }
}
