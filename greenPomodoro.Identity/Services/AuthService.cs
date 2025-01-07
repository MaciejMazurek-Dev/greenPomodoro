using greenPomodoro.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;

namespace greenPomodoro.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public string Login(string email, string password)
        {
            return "";
        }

        public bool Register(string email, string password)
        {
            return false;
        }
    }
}
