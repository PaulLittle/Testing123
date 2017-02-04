using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SAC_Web_Application.Models.ClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_Web_Application.Data
{
    public static class DbContextSeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            // Get an instance of the DbContext from the DI container
            using (var context = app.ApplicationServices.GetRequiredService<ClubContext>())
            {
                //perform seed operations
                /*context.Members.Add(new Members
                {
                    Address1 = "long road",
                    Address2 = "farm ville",
                    City = "Sligo",
                    County = "Sligo",
                    CountyOfBirth = "Mayo",
                    DateRegistered = DateTime.Now,
                    DOB = DateTime.Now,
                    Email = "testemail@email.com",
                    FirstName = "Seeder",
                    Gender = "Male",
                    LastName = "Man",
                    PhoneNumber = "353672728",
                    PostCode = "none",
                    Province = "Ulster",
                    TeamName = "Cutting Edge"
                });

                // Save changes and release resources
                context.SaveChanges();
                context.Dispose();*/
            }
        }
    }
}
