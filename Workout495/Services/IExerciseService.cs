using System.Collections.Generic;
using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.Services
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetExercisesByUserAsync(string userId);
        Task<int> SaveChangesAsync();
        Task<Exercise> CreateNewAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task<int> RemoveExercise(Exercise exercise);
    }
}