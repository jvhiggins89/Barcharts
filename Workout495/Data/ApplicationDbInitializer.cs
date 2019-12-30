using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Models;
using Workout495.Services;
using Workout495.ViewModels;

namespace Workout495.Data
{
    public  class ApplicationDbInitializer
    {
        
        public static string SeedUsers(UserManager<ApplicationUser> userManager)
        {

            var userKey = "";
            var foundUser = userManager.FindByEmailAsync("apples@apples.com").Result;
            if (foundUser == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "apples@apples.com",
                    Email = "apples@apples.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;

                userKey = userManager.FindByEmailAsync("apples@apples.com").Result.Id;
            }
            else
            {
                userKey = foundUser.Id;
            }

            return userKey;
        }      

       
    }
}
