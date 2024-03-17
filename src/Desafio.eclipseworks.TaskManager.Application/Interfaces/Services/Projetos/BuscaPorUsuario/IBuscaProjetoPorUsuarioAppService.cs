using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario.Dto;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario
{
    public interface IBuscaProjetoPorUsuarioAppService
    {
        Task<Retorno<List<BuscaProjetoPorUsuarioResponse>>> ExecutarAsync(BuscaProjetoPorUsuarioRequest request);
    }
}
