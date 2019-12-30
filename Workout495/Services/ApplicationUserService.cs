using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Workout495.Models;
using System.Security.Claims;

namespace Workout495.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            var currentUser = claimsPrincipal;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return  await _userManager.FindByIdAsync(currentUserName);
        }
    }
}
