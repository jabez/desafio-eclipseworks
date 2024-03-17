using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas.Dtos;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas
{
    public interface IHistoricoTarefaRepository
    {
        Task<HistoricoTarefa> AdicionarAsync(HistoricoTarefa historico);
        Task AdicionarAsync(List<HistoricoTarefa> historico);
        Task<IEnumerable<HistoricoTarefa>> Where(Expression<Func<HistoricoTarefa, bool>> predicate);
        Task<List<ResultadoRelatorioDesempenhoDto>> ObterNumeroDeTarefasPorUsuario(DateTime dataInicioPeriodo, DateTime dataFimPeriodo);
    }
}
