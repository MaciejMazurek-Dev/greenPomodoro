using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models;
using greenPomodoro.BlazorUI.Services.BaseHttpClient;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace greenPomodoro.BlazorUI.Services
{
    public class PomodoroTaskService : BaseHttpService, IPomodoroTaskService
    {
        public PomodoroTaskService(IClient client) : base(client)
        {
        }

        public async Task<List<TaskVM>> GetAllTasks()
        {
            List<TaskDto> tasks = await _client.GetAllIssues();

            List<TaskVM> result = new();
            foreach (TaskDto task in tasks)
            {
                result.Add(new TaskVM
                {
                    DueDate = task.DueDate,
                    EstimatedPomodoros = task.EstimatedPomodoros,
                    FinishedPomodoros = task.FinishedPomodoros,
                    Id = task.Id,
                    LongBreakLength = task.LongBreakLength,
                    Name = task.Name,
                    PomodoroLength = task.PomodoroLength,
                    ShortBreakLength = task.ShortBreakLength,
                });
            }
            return result;
        }

        public async Task<bool> CreateTask(CreateTaskVM task)
        {
            CreateTaskCommand command = new CreateTaskCommand
            {
                DueDate = task.DueDate,
                EstimatedPomodoros = task.EstimatedPomodoros,
                LongBreakLength = task.LongBreakLength,
                Name = task.Name,
                PomodoroLength = task.PomodoroLength,
                ShortBreakLength = task.ShortBreakLength,
            };
            bool result = await _client.CreateTask(command);
            return result;
        }
    }
}
