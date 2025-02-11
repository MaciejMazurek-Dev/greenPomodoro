using greenPomodoro.BlazorUI.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace greenPomodoro.BlazorUI.Services.BaseHttpClient
{
    public class Client : IClient
    {
        private readonly HttpClient _httpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDto>> GetAllIssues()
        {
            HttpRequestMessage request = new(HttpMethod.Get, "/api/task");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            List<TaskDto>? tasks = await response.Content.ReadFromJsonAsync<List<TaskDto>>();
            return tasks;
        }

        public async Task<bool> CreateTask(CreateTaskCommand command)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/task", command);
            bool result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

        public async Task<bool> RegisterUser(RegisterRequest registerRequest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/auth/register", registerRequest);
            bool result = await response.Content.ReadFromJsonAsync<bool>();
            return result;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest loginRequest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/auth/login", loginRequest);
            LoginResponse result = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return result;
        }
    }

    //DTO Classes
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int FinishedPomodoros { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
    }
    public class CreateTaskCommand
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int EstimatedPomodoros { get; set; }
        public int PomodoroLength { get; set; }
        public int ShortBreakLength { get; set; }
        public int LongBreakLength { get; set; }
        public string? UserId { get; set; }
    }
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
