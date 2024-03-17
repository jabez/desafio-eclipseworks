using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Relatorio
{
    public class RelatorioDesempenhoAppService : IRelatorioDesempenhoAppService
    {
        private readonly IHistoricoTarefaRepository _historicoTarefaRepository;

        public RelatorioDesempenhoAppService(IHistoricoTarefaRepository historicoTarefaRepository)
        {
            _historicoTarefaRepository = historicoTarefaRepository;
        }

        public async Task<Retorno<List<RelatorioDesempenhoResponse>>> ExecutarAsync()
        {


            var periodoInicial = DateTime.UtcNow.AddDays(-30);
            var periodoFinal = DateTime.UtcNow;
            var resultadoRelatorio = await _historicoTarefaRepository.ObterNumeroDeTarefasPorUsuario(periodoInicial, periodoFinal);


            return new Retorno<List<RelatorioDesempenhoResponse>>
            {
                Sucesso = true,
                Dados = resultadoRelatorio.Select(x => new RelatorioDesempenhoResponse(x.Nome, x.QuantidadeTarefasConcluidas)).ToList()
            };
                
        }
    }
}
