using Desafio.EclipseWorks.TaskManager.Infra.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Desafio.EclipseWorks.TaskManager.Api.Configurations.DataBase
{
    public static class DatabaseExtension
    {
        public static void AddMyDatabaseExtension(
            this IServiceCollection service,
            ConfigurationManager configuration)
        {
            service.AddDbContext<TaskManagerContext>(options =>
                options.UseSqlServer(
                   configuration.GetSection("ConnectionStrings:taskManagerContext").Value,
                    p =>
                    {
                        p.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null);
                    })
                .EnableSensitiveDataLogging());
        }

        public static void UseMyMigrations(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            serviceScope.ServiceProvider.GetService<TaskManagerContext>().Database.Migrate();

        }
    }
}
