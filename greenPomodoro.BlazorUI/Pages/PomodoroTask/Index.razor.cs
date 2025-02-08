using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models;

namespace greenPomodoro.BlazorUI.Pages.PomodoroTask
{
    public partial class Index
    {
        private readonly IPomodoroTaskService _taskService;
        public List<TaskVM> PomodoroTasks { get; set; } = new();

        public Index(IPomodoroTaskService taskService)
        {
            _taskService = taskService;
        }
        protected override async Task OnInitializedAsync()
        {
            PomodoroTasks = await _taskService.GetAllTasks();
        }
    }
}
