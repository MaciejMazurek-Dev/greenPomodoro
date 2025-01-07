using greenPomodoro.Identity.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace greenPomodoro.Identity
{
    public static class RegisterIdentityServices
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = greenPomodoro; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentityCore<IdentityUser>()
            .AddEntityFrameworkStores<AuthDbContext>();
            
            return services;
        }
    }
}
