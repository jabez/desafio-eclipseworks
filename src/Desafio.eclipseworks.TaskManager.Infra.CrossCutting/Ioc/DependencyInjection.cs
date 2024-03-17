using Desafio.EclipseWorks.TaskManager.Infra.CrossCutting.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.eclipseworks.TaskManager.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.AddMyServices();
            services.AddMyRepositories();

            return services;
        }
    }
}
