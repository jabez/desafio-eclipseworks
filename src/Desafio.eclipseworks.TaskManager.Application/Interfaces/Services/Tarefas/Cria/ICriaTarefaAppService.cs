using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria
{
    public interface ICriaTarefaAppService
    {
        Task<Retorno<CriaTarefaResponse>> ExecutarAsync(CriaTarefaRequest request);
    }
}
