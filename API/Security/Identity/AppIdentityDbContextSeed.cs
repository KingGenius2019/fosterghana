using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
          public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
       
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Super Doer",
                        Email = "superdoer@admin.com",
                        UserName = "superdoer@admin.com",
                      
                    },
                    new AppUser
                    {
                        DisplayName = "Kingsley Osei Owusu",
                        Email = "kinggeniusgh@gmail.com",
                        UserName = "kinggeniusgh@gmail.com"
                    }
                 
                };

                var roles = new List<AppRole>
                {
                    new AppRole {Name = "Admin"},
                    new AppRole {Name = "Social-Worker"},
                    new AppRole {Name = "DSW-Regional-Head"},
                    new AppRole {Name = "Fostercare-Staff"},
                    new AppRole {Name = "Fostercare-Head"},
                    new AppRole {Name = "Committee-Member"},
                    new AppRole {Name = "Applicant"},
                    new AppRole {Name = "No-Roll-Set"},
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Applicant");
                    if (user.Email == "superdoer@admin.com") await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}