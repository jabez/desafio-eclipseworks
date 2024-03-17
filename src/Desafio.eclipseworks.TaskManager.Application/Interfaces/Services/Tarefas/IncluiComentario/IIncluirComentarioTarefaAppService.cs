using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario
{
    public interface IIncluirComentarioTarefaAppService
    {
        Task<Retorno<IncluirComentarioTarefaResponse>> ExecutarAsync(IncluirComentarioTarefaRequest request);
    }
}
