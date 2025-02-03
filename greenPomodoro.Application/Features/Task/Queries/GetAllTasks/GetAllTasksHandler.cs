using greenPomodoro.Application.Contracts.Persistence;
using MediatR;

namespace greenPomodoro.Application.Features.Task.Queries.GetAllTasks
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTasksHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllTasks(request.UserId);
            List<TaskDto> result = new List<TaskDto>();
            foreach(var task in tasks)
            {
                result.Add(new TaskDto
                {
                    DueDate = task.DueDate,
                    EstimatedPomodoros = task.EstimatedPomodoros,
                    FinishedPomodoros = task.FinishedPomodoros,
                    Id = task.Id,
                    LongBreakLength = task.LongBreakLength,
                    Name = task.Name,
                    PomodoroLength = task.PomodoroLength,
                    ShortBreakLength = task.PomodoroLength
                });
            }
            return result;
        }
    }
}
