using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.Services
{
    public interface IWorkoutService
    {
        Task<List<Workout>> GetWorkoutsByUserAsync(string userId);

        Task<Workout> GetWorkoutByIdAsync(int id);

        Task<List<Exercise>> GetAvailableExercisesAsync(string userId);

        Task<int> SaveChangesAsync();

        Task<Workout> CreateNewAsync();

    }
}
