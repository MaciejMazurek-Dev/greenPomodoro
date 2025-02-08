using greenPomodoro.Application.Contracts.Persistence;
using greenPomodoro.Domain;
using greenPomodoro.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace greenPomodoro.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly GPDbContext _dbContext;

        public TaskRepository(GPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateTaskAsync(PomodoroTask task)
        {
            await _dbContext.AddAsync(task);
            var result = await _dbContext.SaveChangesAsync();
            return result == 0 ? false : true;
        }
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var entity = await _dbContext.PomodoroTasks.SingleAsync(t => t.Id == id);
            _dbContext.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result == 0 ? false : true;
        }
        public async Task<List<PomodoroTask>> GetAllTasks(string userId)
        {
            var result = await _dbContext.PomodoroTasks
                .Where(t => t.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }
    }
}
