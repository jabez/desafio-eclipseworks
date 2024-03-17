using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria
{
    public interface ICriaProjetoAppService
    {
        Task<Retorno<CriaProjetoResponse>> ExecutarAsync(CriaProjetoRequest request);
    }
}
