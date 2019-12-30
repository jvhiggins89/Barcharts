using System.Collections.Generic;
using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.Services
{
    public interface IProgressPointsService
    {
        Task<List<ProgressPoints>> GetProgressPointsByUserAsync(string userId);
        Task<ProgressPoints> GetProgressPointsByIdAsync(int userId);
        Task<int> SaveChangesAsync();
        Task<ProgressPoints> CreateNewAsync();
        Task<int> RemoveProgressPoints(ProgressPoints progressPoint);
    }
}