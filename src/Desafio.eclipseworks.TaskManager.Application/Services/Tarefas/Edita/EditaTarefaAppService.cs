using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Edita
{
    public class EditaTarefaAppService : IEditaTarefaAppService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHistoricoTarefaRepository _historicoTarefaRepository;

        public EditaTarefaAppService(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository, IHistoricoTarefaRepository historicoTarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
            _historicoTarefaRepository = historicoTarefaRepository;
        }

        public async Task<Retorno<EditaTarefaResponse>> ExecutarAsync(EditaTarefaRequest request)
        {
            var tarefa = await ObterTarefaAsync(request);
            var usuario = await ObterUsuarioAsync(request);

            tarefa.AtualizarTitulo(request.Titulo, usuario)
                  .AtualizarDescricao(request.Descricao, usuario)
                  .AtualizarDataVencimento(request.DataVencimento, usuario)
                  .AtualizarStatus(request.Status, usuario);
            

            await _historicoTarefaRepository.AdicionarAsync(tarefa.Historicos.ToList());
            await _tarefaRepository.AtualizarAsync(tarefa);
            

            return new Retorno<EditaTarefaResponse>()
            {
                Sucesso = true,
                Dados = new EditaTarefaResponse()
                {
                    Idtarefa = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    DataVencimento = tarefa.DataVencimento,
                    Prioridade = tarefa.Prioridade,
                    Status = tarefa.Status,
                    IdUsuario = tarefa.IdUsuario,
                    IdProjeto = tarefa.IdProjeto,
                }
            };

        }

        private async Task<Tarefa> ObterTarefaAsync(EditaTarefaRequest request)
        {
            var tarefa = await _tarefaRepository.ObterAsync(request.IdTarefa);
            if (tarefa == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Tarefa", "a"));

            return tarefa;
        }
        private async Task<Usuario> ObterUsuarioAsync(EditaTarefaRequest request)
        {
            var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
            if (usuario == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Usuario", "o"));

            return usuario;
        }
    }
}
