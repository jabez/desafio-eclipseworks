using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos
{
    public interface IBuscaTodosUsuariosAppService
    {
        Task<Retorno<List<BuscaTodosUsuariosResponse>>> ExecutarAsync(BuscaTodosUsuariosRequest request);
    }
}
