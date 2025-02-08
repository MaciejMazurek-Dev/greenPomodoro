using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models;

namespace greenPomodoro.BlazorUI.Pages.PomodoroTask
{
    public partial class Create
    {
        private readonly IPomodoroTaskService _taskService;
        public CreateTaskVM Model { get; set; } = new();
        public Create(IPomodoroTaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task CreateTask()
        {
            bool result = await _taskService.CreateTask(Model);
        }
    }
}
