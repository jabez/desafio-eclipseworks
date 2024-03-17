using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto.Dto;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto
{
    public interface IBuscaTarefaPorProjetoAppService
    {
        Task<Retorno<List<BuscaTarefaPorProjetoResponse>>> ExecutarAsync(BuscaTarefaPorProjetoRequest request);
    }
}
