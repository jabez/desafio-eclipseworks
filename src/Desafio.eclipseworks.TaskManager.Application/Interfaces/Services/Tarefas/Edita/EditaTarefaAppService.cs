using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita
{
    public interface IEditaTarefaAppService
    {
        Task<Retorno<EditaTarefaResponse>> ExecutarAsync(EditaTarefaRequest request);
    }
}
