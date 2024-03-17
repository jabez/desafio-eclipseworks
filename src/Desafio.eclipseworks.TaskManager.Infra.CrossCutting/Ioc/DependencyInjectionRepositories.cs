using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Comentarios;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Comentarios;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Projetos;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.eclipseworks.TaskManager.Infra.CrossCutting.Ioc
{
    internal static class DependencyInjectionRepositories
    {
        internal static IServiceCollection AddMyRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IHistoricoTarefaRepository, HistoricoTarefaRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();

            return services;
        }
    }
}
