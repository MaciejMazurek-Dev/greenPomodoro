using Blazored.LocalStorage;
using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Models.Auth;
using greenPomodoro.BlazorUI.Services.BaseHttpClient;

namespace greenPomodoro.BlazorUI.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
        private readonly ILocalStorageService _localStorage;
        public AuthService(IClient client, ILocalStorageService localStorage) : base(client)
        {
            _localStorage = localStorage;
        }
        public async Task<bool> Register(RegisterVM registerVM)
        {
            RegisterRequest registerRequest = new RegisterRequest
            {
                Email = registerVM.Email,
                Password = registerVM.Password
            };
            bool result = await _client.RegisterUser(registerRequest);
            return result;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            LoginRequest loginRequest = new LoginRequest
            {
                Email = loginVM.Email,
                Password = loginVM.Password
            };
            LoginResponse loginResponse = await _client.LoginUser(loginRequest);
            if(loginResponse.AccessToken == string.Empty)
            {
                return false;
            }
            await _localStorage.SetItemAsStringAsync("accesstoken", loginResponse.AccessToken);
            await _localStorage.SetItemAsStringAsync("refreshtoken", loginResponse.RefreshToken);
            return true;
        }
    }
}
