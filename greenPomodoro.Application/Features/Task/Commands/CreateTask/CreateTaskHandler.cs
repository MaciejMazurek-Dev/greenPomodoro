using greenPomodoro.Application.Contracts.Persistence;
using greenPomodoro.Domain;
using MediatR;

namespace greenPomodoro.Application.Features.Task.Commands.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;
        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            PomodoroTask task = new PomodoroTask
            {
                DueDate = request.DueDate,
                EstimatedPomodoros = request.EstimatedPomodoros,
                LongBreakLength = request.LongBreakLength == 0 ? 15 : request.LongBreakLength,
                CreationDate = DateTime.UtcNow,
                FinishedPomodoros = 0,
                Name = request.Name,
                PomodoroLength = request.PomodoroLength == 0 ? 25 : request.PomodoroLength,
                ShortBreakLength = request.ShortBreakLength == 0 ? 5 : request.ShortBreakLength,
                UserId = request.UserId
            };
            return _taskRepository.CreateTaskAsync(task);
        }
    }
}
