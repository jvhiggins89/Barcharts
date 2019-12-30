using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Data;
using Workout495.Models;

namespace Workout495.Services
{
    public class ProgressPointService : IProgressPointsService
    {
        private readonly Workout495Context _context;

        public ProgressPointService(Workout495Context context)
        {
            _context = context;
        }

        public async Task<List<ProgressPoints>> GetProgressPointsByUserAsync(string userId)
        {
            return await _context.ProgressPoints.Where(e => e.User.Id == userId)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<ProgressPoints> GetProgressPointsByIdAsync(int userId)
        {
            return await _context.ProgressPoints.FindAsync(userId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<ProgressPoints> CreateNewAsync()
        {
            var newProgressPoint = new ProgressPoints();
            await _context.ProgressPoints.AddAsync(newProgressPoint);
            return newProgressPoint;
        }

        public async Task<int> RemoveProgressPoints(ProgressPoints progressPoint)
        {
            _context.ProgressPoints.Remove(progressPoint);
            return await SaveChangesAsync();
        }

    }
}
