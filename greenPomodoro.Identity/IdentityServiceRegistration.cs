using greenPomodoro.Identity.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using greenPomodoro.Application.Contracts.Identity;
using greenPomodoro.Identity.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace greenPomodoro.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            string connectionString = @"Server=localhost;Port=3306;Database=GPIdentity;Uid=root;Pwd=mysql;";
            var serverVersion = new MySqlServerVersion(new Version(9, 0, 0));

            services.AddDbContext<AuthDbContext>(options =>
                options.UseMySql(connectionString, serverVersion));
            services.AddIdentityCore<IdentityUser>()
                .AddSignInManager<SignInManager<IdentityUser>>()
                .AddEntityFrameworkStores<AuthDbContext>();
            services.AddAuthentication()
                .AddJwtBearer("jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidIssuer = "greenpomodoro",
                    // TODO: Ensure the secret key is securely stored in a safe location.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET-KEY-jksndjkrdbfuiebyufebhfbhefbehjhfbjhfshdbsdjhcbsdjhvbhdbvjhfuiwfw78yeufuisjsdvsjkld")),
                };
            });
            services.AddAuthorization();
            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}
