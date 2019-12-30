using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Data;
using Workout495.Models;

namespace Workout495.Services
{
    public class GoalService : IGoalsService
    {
        private readonly Workout495Context _context;

        public GoalService(Workout495Context context)
        {
            _context = context;
        }

        public async Task<List<Goals>> GetGoalsByUserAsync(string userId)
        {
            return await _context.Goals.Where(e => e.User.Id == userId)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Goals> GetGoalsByIdAsync(int id)
        {
            return await _context.Goals.Include(x => x.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> RemoveGoals(Goals goal)
        {
            _context.Goals.Remove(goal);
            return await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Goals> CreateNewAsync()
        {
            var newGoal = new Goals();
            await _context.Goals.AddAsync(newGoal);
            return newGoal;
        }

    }
}
