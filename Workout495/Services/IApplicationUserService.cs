using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.Services
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetCurrentUserAsync(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
    }
}