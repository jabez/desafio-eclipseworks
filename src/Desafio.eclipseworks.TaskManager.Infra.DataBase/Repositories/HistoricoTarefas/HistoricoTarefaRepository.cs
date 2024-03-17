using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.HistoricoTarefas
{
    public class HistoricoTarefaRepository : IHistoricoTarefaRepository
    {
        public readonly TaskManagerContext _taskManagerContext;

        public HistoricoTarefaRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public async Task<HistoricoTarefa> AdicionarAsync(HistoricoTarefa historico)
        {
             await _taskManagerContext.HistoricosTarefa.AddAsync(historico);
             await _taskManagerContext.SaveChangesAsync();
             return historico;
            
        }

        public async Task<IEnumerable<HistoricoTarefa>> Where(Expression<Func<HistoricoTarefa, bool>> predicate)
        {

            return await _taskManagerContext.HistoricosTarefa.Where(predicate).ToListAsync();
        }

        public async Task AdicionarAsync(List<HistoricoTarefa> historico)
        {
             await _taskManagerContext.HistoricosTarefa.AddRangeAsync(historico);
             await _taskManagerContext.SaveChangesAsync();
        }

        public async Task<List<ResultadoRelatorioDesempenhoDto>> ObterNumeroDeTarefasPorUsuario(DateTime dataInicioPeriodo,DateTime dataFimPeriodo)
        {
            var resultado = await _taskManagerContext
                            .HistoricosTarefa
                            .Where(x => x.CampoAlterado.Equals("status")
                                  && x.NovoValor == Status.Concluida.ToString()
                                  && x.DataModificacao >= dataInicioPeriodo && x.DataModificacao <= dataFimPeriodo)
                            .AsNoTracking()
                            .GroupBy(x => x.NomeUsuarioAlteracao)
                            .ToListAsync();

            return resultado.Select(x => new ResultadoRelatorioDesempenhoDto(x.Key, x.Count())).ToList();
        }
    }
}
