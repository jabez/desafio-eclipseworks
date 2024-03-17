using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos;
using Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.BuscaPorUsuario;
using Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Services.Relatorio;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.BuscaPorProjeto;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Edita;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.IncluirComentarios;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Services.Usuarios.BuscaTodos;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.EclipseWorks.TaskManager.Infra.CrossCutting.Ioc
{
    internal static class DependencyInjectionServices
    {
        internal static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<ICriaProjetoAppService, CriaProjetoAppService>();
            services.AddScoped<IBuscaTodosUsuariosAppService, BuscaTodosUsuariosAppService>();
            services.AddScoped<IBuscaProjetoPorUsuarioAppService, BuscaProjetoPorUsuarioAppService>();
            services.AddScoped<ICriaTarefaAppService, CriaTarefaAppService>();
            services.AddScoped<IBuscaTarefaPorProjetoAppService, BuscaTarefaPorProjetoAppService>();
            services.AddScoped<IEditaTarefaAppService, EditaTarefaAppService>();
            services.AddScoped<IRemoveTarefaAppService, RemoveTarefaAppService>();
            services.AddScoped<IRemoveProjetoAppService, RemoveProjetoAppService>();
            services.AddScoped<IIncluirComentarioTarefaAppService, IncluirComentarioTarefaAppService>();
            services.AddScoped<IRelatorioDesempenhoAppService, RelatorioDesempenhoAppService>();
            
            return services;
        }
    }
}
