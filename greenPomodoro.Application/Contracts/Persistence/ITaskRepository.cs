using greenPomodoro.Domain;

namespace greenPomodoro.Application.Contracts.Persistence
{
    public interface ITaskRepository
    {
        Task<bool> CreateTaskAsync(PomodoroTask task);
        Task<bool> DeleteTaskAsync(int id);
        Task<List<PomodoroTask>> GetAllTasks(string userId);
    }
}
