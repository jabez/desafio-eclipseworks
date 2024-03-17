using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto.Dto;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.BuscaPorProjeto
{
    public class BuscaTarefaPorProjetoAppService : IBuscaTarefaPorProjetoAppService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public BuscaTarefaPorProjetoAppService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Retorno<List<BuscaTarefaPorProjetoResponse>>> ExecutarAsync(BuscaTarefaPorProjetoRequest request)
        {
            var tarefas = await _tarefaRepository.Where(x => x.IdProjeto == request.IdProjeto && x.Ativa == true);
            if (!tarefas.Any())
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Tarefa", "a"));

            return new Retorno<List<BuscaTarefaPorProjetoResponse>>()
            {
                Sucesso = true,
                Dados = tarefas.ToList().Select(x => new BuscaTarefaPorProjetoResponse()
                {
                    Idtarefa = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    DataVencimento = x.DataVencimento,
                    Prioridade = x.Prioridade,
                    Status = x.Status,
                    IdUsuario = x.IdUsuario,
                    IdProjeto = x.IdProjeto
                }).ToList(),
            };
        }
    }
}
