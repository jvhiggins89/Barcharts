using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout495.Data;
using Workout495.Models;

namespace Workout495.Services
{
    public class WorkoutService : IWorkoutService
    {
        
        private readonly Workout495Context _context;

        public WorkoutService(Workout495Context context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetWorkoutsByUserAsync(string userId)
        {
            return await _context.Workout.Where(e => e.User.Id == userId && e.Active == true)
                .Include(x => x.Exercises)
                .Include(x => x.User)
                .ToListAsync();

        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workout.Where(e => e.Id == id)
                .Include(x => x.Exercises)
                .Include(x => x.User)
                .FirstOrDefaultAsync<Workout>();
        }

        public async Task<List<Exercise>> GetAvailableExercisesAsync(string userId)
        {
            return await _context.Exercise.Where(e => e.User.Id == userId && e.WorkoutId == null)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Workout> CreateNewAsync()
        {
            var newWorkout = new Workout();
            await _context.Workout.AddAsync(newWorkout);
            return newWorkout;
        }
        
    }
}
