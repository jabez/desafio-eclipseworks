using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Remove
{
    public class RemoveTarefaAppService : IRemoveTarefaAppService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHistoricoTarefaRepository _historicoTarefaRepository;

        public RemoveTarefaAppService(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository, IHistoricoTarefaRepository historicoTarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
            _historicoTarefaRepository = historicoTarefaRepository;
        }

        public async Task ExecutarAsync(RemoveTarefaRequest request)
        {
            var tarefa = await ObterTarefaAsync(request);
            var usuario = await ObterUsuarioAsync(request);

            tarefa.InativarTarefa(usuario);
            await _historicoTarefaRepository.AdicionarAsync(tarefa.Historicos.ToList());
            await _tarefaRepository.AtualizarAsync(tarefa);
        }

        private async Task<Tarefa> ObterTarefaAsync(RemoveTarefaRequest request)
        {
            var tarefa = await _tarefaRepository.ObterAsync(request.IdTarefa);
            if (tarefa == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Tarefa", "a"));

            return tarefa;
        }

        private async Task<Usuario> ObterUsuarioAsync(RemoveTarefaRequest request)
        {
            var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
            if (usuario == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Usuario", "o"));

            return usuario;
        }
    }
}
