using greenPomodoro.BlazorUI.Models.Auth;

namespace greenPomodoro.BlazorUI.Contracts
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterVM registerVM);
        public Task<bool> Login(LoginVM loginVM);
    }
}
