using greenPomodoro.Domain;
using Microsoft.EntityFrameworkCore;

namespace greenPomodoro.Persistence.DatabaseContext
{
    public class GPDbContext : DbContext
    {
        public GPDbContext(DbContextOptions<GPDbContext> options)
            : base(options)
        {
        }
        public DbSet<PomodoroTask> PomodoroTasks { get; set; }
    }
}
