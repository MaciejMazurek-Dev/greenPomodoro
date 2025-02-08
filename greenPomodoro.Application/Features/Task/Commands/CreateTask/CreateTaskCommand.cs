using MediatR;

namespace greenPomodoro.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
        public string? UserId { get; set; }
    }
}
