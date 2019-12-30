using System.Collections.Generic;
using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.Services
{
    public interface IGoalsService
    {
        Task<List<Goals>> GetGoalsByUserAsync(string userId);
        Task<Goals> GetGoalsByIdAsync(int id);
        Task<int> SaveChangesAsync();
        Task<Goals> CreateNewAsync();
        Task<int> RemoveGoals (Goals goal);
    }
}