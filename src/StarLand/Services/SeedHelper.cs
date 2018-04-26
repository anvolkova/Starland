using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarLand.Models;

namespace StarLand.Services
{
    public static class SeedHelper
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //DataService<Profile> profileDataService = new DataService<Profile>();
            DataService<Planet> planetDataService = new DataService<Planet>();

            //add customer role
            if (await roleManager.FindByNameAsync("Customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //add planet samples            
            if (planetDataService.GetSingle(p => p.Name == "Ceres") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Ceres",
                    Size = 974.6,
                    Distance = 2.76596,
                    Price = 0.99,
                    Picture = "Ceres.jpg",
                    IsSold = 0                    
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Eris") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Eris",
                    Size = 3000,
                    Distance = 67.6681,
                    Price = 1.99,
                    Picture = "Eris.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Haumea") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Haumea",
                    Size = 1960,
                    Distance = 43.335,
                    Price = 0.99,
                    Picture = "Haumea.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Jupiter") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Jupiter",
                    Size = 142800,
                    Distance = 5.20,
                    Price = 4.99,
                    Picture = "Jupiter.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Makemake") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Makemake",
                    Size = 1900,
                    Distance = 45.791,
                    Price = 1.99,
                    Picture = "Makemake.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Mars") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Mars",
                    Size = 6787,
                    Distance = 1.52,
                    Price = 3.99,
                    Picture = "Mars.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Mercury") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Mercury",
                    Size = 4878,
                    Distance = 0.39,
                    Price = 4.99,
                    Picture = "Mercury.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Neptune") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Neptune",
                    Size = 49528,
                    Distance = 30.06,
                    Price = 3.99,
                    Picture = "Neptune.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Pluto") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Pluto",
                    Size = 2300,
                    Distance = 39.44,
                    Price = 3.99,
                    Picture = "Pluto.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Saturn") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Saturn",
                    Size = 120000,
                    Distance = 9.54,
                    Price = 3.99,
                    Picture = "Saturn.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Uranus") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Uranus",
                    Size = 51118,
                    Distance = 19.18,
                    Price = 2.99,
                    Picture = "Uranus.jpg",
                    IsSold = 0
                });
            }
            if (planetDataService.GetSingle(p => p.Name == "Venus") == null)
            {
                planetDataService.Create(new Planet
                {
                    Name = "Venus",
                    Size = 12104,
                    Distance = 0.72,
                    Price = 1.99,
                    Picture = "Venus.jpg",
                    IsSold = 0
                });
            }
        }
    }
}
