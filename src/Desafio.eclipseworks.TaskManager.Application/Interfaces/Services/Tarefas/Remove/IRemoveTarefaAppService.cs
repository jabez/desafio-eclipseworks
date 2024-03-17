using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove
{
    public interface IRemoveTarefaAppService
    {
        Task ExecutarAsync(RemoveTarefaRequest request);
    }
}
