using greenPomodoro.BlazorUI.Models;

namespace greenPomodoro.BlazorUI.Contracts
{
    public interface IPomodoroTaskService
    {
        Task<List<TaskVM>> GetAllTasks();
        Task<bool> CreateTask(CreateTaskVM task);
    }
}
