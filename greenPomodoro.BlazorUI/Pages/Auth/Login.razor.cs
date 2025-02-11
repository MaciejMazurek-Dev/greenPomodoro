using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models.Auth;
using Microsoft.AspNetCore.Components;

namespace greenPomodoro.BlazorUI.Pages.Auth
{
    public partial class Login
    {
        public LoginVM Model { get; set; } = new();
        private readonly IAuthService _authService;
        private readonly NavigationManager _navigationManager;
        public Login(IAuthService authService, NavigationManager navigationManager)
        {
            _authService = authService;
            _navigationManager = navigationManager;
        }

        public async Task LoginUser()
        {
            var result = await _authService.Login(Model);
            if(result)
            {
                _navigationManager.NavigateTo("/task");
            }
            // TODO: Add an error message for incorrect login credentials.
        }

        public async Task LoginDemo()
        {
            Model.Email = "admin@example.com";
            Model.Password = "P@ssword2024";
            var result = await _authService.Login(Model);
            if (result)
            {
                _navigationManager.NavigateTo("/task");
            }
        }
    }
}
