using greenPomodoro.Application.Contracts.Persistence;
using greenPomodoro.Persistence.DatabaseContext;
using greenPomodoro.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace greenPomodoro.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            string connectionString = @"Server=localhost;Port=3306;Database=GPDatabase;Uid=root;Pwd=mysql;";
            var serverVersion = new MySqlServerVersion(new Version(9, 0, 0));

            services.AddDbContext<GPDbContext>(options =>
                options.UseMySql(connectionString, serverVersion));
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}
