using greenPomodoro.BlazorUI.Models;

namespace greenPomodoro.BlazorUI.Services.BaseHttpClient
{
    public interface IClient
    {
        Task<List<TaskDto>> GetAllIssues();
        Task<bool> CreateTask(CreateTaskCommand command);
        Task<bool> RegisterUser(RegisterRequest registerRequest);
        Task<LoginResponse> LoginUser(LoginRequest loginRequest);
    }
}
