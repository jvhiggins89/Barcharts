using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Data;
using Workout495.Models;

namespace Workout495.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly Workout495Context _context;

        public ExerciseService(Workout495Context context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetExercisesByUserAsync(string userId)
        {
            return await _context.Exercise.Where(e => e.User.Id == userId)
                .Include(x => x.Workout)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _context.Exercise.Include(x => x.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> RemoveExercise(Exercise exercise)
        {
            _context.Exercise.Remove(exercise);
            return await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Exercise> CreateNewAsync()
        {
            var newExercise = new Exercise();
            await _context.Exercise.AddAsync(newExercise);
            return newExercise;
        }
    }
}
