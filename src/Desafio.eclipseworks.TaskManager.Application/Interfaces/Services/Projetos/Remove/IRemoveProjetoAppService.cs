using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove
{
    public interface IRemoveProjetoAppService
    {
        Task ExecutarAsync(RemoveProjetoRequest request);
    }
}
