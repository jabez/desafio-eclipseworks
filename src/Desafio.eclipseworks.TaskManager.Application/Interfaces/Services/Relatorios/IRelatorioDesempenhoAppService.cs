using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios.Dtos;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios
{
    public interface IRelatorioDesempenhoAppService
    {
        Task<Retorno<List<RelatorioDesempenhoResponse>>> ExecutarAsync();
    }
}
