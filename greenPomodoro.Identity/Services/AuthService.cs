using greenPomodoro.Application.Contracts.Identity;
using greenPomodoro.Application.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace greenPomodoro.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        // TODO: Ensure the secret key is securely stored in a safe location.
        private readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET-KEY-jksndjkrdbfuiebyufebhfbhefbehjhfbjhfshdbsdjhcbsdjhvbhdbvjhfuiwfw78yeufuisjsdvsjkld"));

        public AuthService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<LoginResponse> Login(LoginRequest loginModel)
        {
            LoginResponse response = new();
            IdentityUser? user = await _userManager.FindByNameAsync(loginModel.Email);
            if(user == null)
            {
                return response;
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (result.Succeeded)
            {
                string accessToken = GenerateAccessToken(loginModel.Email);
                string refreshToken = GenerateRefreshToken(loginModel.Email);
                response.AccessToken = accessToken;

                // TODO: Store the refresh tokens securely in the database to enable token management and revocation.
                response.RefreshToken = refreshToken;
                return response;
            }
            return response;
        }

        public async Task<bool> Register(RegisterRequest registerModel)
        {
            if(registerModel.Password == string.Empty ||
                registerModel.Email == string.Empty) 
            {
                return false;
            }
            IdentityUser user = new IdentityUser(registerModel.Email);
            IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);
            return result.Succeeded;
        }

        public string GenerateAccessToken(string userName)
        {
            SigningCredentials credentials = new SigningCredentials(
                _securityKey, 
                SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = "greenpomodoro",
                Subject = new ClaimsIdentity("jwt", userName, "user"),
                // TODO: Reduce expiration time for access token
                Expires = DateTime.UtcNow.AddHours(48),
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateRefreshToken(string userName)
        {
            SigningCredentials credentials = new SigningCredentials(
                _securityKey,
                SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = "greenpomodoro",
                Subject = new ClaimsIdentity("jwt", userName, "user"),
                Expires = DateTime.UtcNow.AddHours(48)
            };
            JwtSecurityTokenHandler tokenHandler = new();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
