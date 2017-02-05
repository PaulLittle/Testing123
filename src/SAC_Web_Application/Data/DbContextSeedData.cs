using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SAC_Web_Application.Models;
using SAC_Web_Application.Models.ClubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SAC_Web_Application.Data
{
    public static class DbContextSeedData
    {
        static private readonly UserManager<ApplicationUser> _userManager;
        static private readonly RoleManager<ApplicationUser> _roleManager;
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

            using (var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
            {
                // Create user roles

                ApplicationUser user1 = context.Users.Where(a => a.Email == "dave1633@live.com").First();
                ApplicationUser user2 = context.Users.Where(a => a.Email == "paull1068@gmail.com").First();

                var adminRole = _roleManager.FindByNameAsync("Admin");

                if (adminRole == null)
                {
                    //_roleManager.CreateAsync(new IdentityRole("Admin"))
                    
                }

                /*var userClaims = new List<Claim> { new Claim("Admin", user1.Email), new Claim("Admin", user2.Email) };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, user1.Email));
                HttpContext SignInAsync("app", principal);*/
            }
        
        }
    }
}
