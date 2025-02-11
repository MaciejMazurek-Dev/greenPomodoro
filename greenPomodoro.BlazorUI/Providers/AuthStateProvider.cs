using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace greenPomodoro.BlazorUI.Providers
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        public AuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState authenticationState = new(new ClaimsPrincipal());
            string? accessToken = await _localStorage.GetItemAsStringAsync("accesstoken");
            if(accessToken == null)
            {
                return authenticationState;
            }

            JsonWebTokenHandler jwtHandler = new();
            JsonWebToken jwtToken = jwtHandler.ReadJsonWebToken(accessToken);
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, jwtToken.Subject)
            };
            ClaimsIdentity claimsIdentity = new(claims);
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);
            return authenticationState = new(claimsPrincipal);
        }
    }
}
