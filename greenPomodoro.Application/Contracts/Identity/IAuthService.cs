using greenPomodoro.Application.Models.Identity;

namespace greenPomodoro.Application.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest loginModel);
        public Task<bool> Register(RegisterRequest registerModel);
        public string GenerateAccessToken(string userName);
        public string GenerateRefreshToken(string userName);
    }
}
