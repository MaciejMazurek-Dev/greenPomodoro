using MediatR;

namespace greenPomodoro.Application.Features.Task.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
        public string? UserId { get; set; }
    }
}
