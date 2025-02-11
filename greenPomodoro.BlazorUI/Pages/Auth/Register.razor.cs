using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models.Auth;

namespace greenPomodoro.BlazorUI.Pages.Auth
{
    public partial class Register
    {
        public RegisterVM Model { get; set; } = new();
        private readonly IAuthService _authService;
        public Register(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task RegisterUser()
        {
            await _authService.Register(Model);
        }
    }
}
