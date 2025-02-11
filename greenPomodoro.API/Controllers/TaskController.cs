using greenPomodoro.Application.Features.Task.Commands.CreateTask;
using greenPomodoro.Application.Features.Task.Queries.GetAllTasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace greenPomodoro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAllTasks()
        {
            List<TaskDto> result = await _mediator.Send(new GetAllTasksQuery
            {
                UserId = "CE5BA681-A8FC-41CC-82B2-C7482D3BBB7D"
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskCommand createTaskRequest)
        {
            createTaskRequest.UserId = "CE5BA681-A8FC-41CC-82B2-C7482D3BBB7D";
            bool result = await _mediator.Send(createTaskRequest);
            return Ok(result);
        }
    }
}
