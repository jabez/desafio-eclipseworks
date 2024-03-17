using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Comentarios;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.IncluirComentarios
{
    public class IncluirComentarioTarefaAppService : IIncluirComentarioTarefaAppService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHistoricoTarefaRepository _historicoTarefaRepository;
        private readonly IComentarioRepository _comentarioRepository;

        public IncluirComentarioTarefaAppService(ITarefaRepository tarefaRepository, 
                                                 IUsuarioRepository usuarioRepository,
                                                 IHistoricoTarefaRepository historicoTarefaRepository,
                                                 IComentarioRepository comentarioRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
            _historicoTarefaRepository = historicoTarefaRepository;
            _comentarioRepository = comentarioRepository;
        }

        public async Task<Retorno<IncluirComentarioTarefaResponse>> ExecutarAsync(IncluirComentarioTarefaRequest request)
        {
            var tarefa = await ObterTarefaAsync(request);
            var usuario = await ObterUsuarioAsync(request);
            
            var comentario = Comentario.Criar(request.Descricao, usuario, tarefa);
            tarefa.IncluirComentario(comentario,usuario);

            await _comentarioRepository.AdicionarAsync(tarefa.Comentarios.ToList());
            
            return new Retorno<IncluirComentarioTarefaResponse>()
            {
                Sucesso = true,
                Dados = new IncluirComentarioTarefaResponse()
                {
                    Id = comentario.Id,
                    Descricao = comentario.Descricao,
                    DataCricao = comentario.DataCricao
                }
            };
        }

        private async Task<Tarefa> ObterTarefaAsync(IncluirComentarioTarefaRequest request)
        {
            var tarefa = await _tarefaRepository.ObterAsync(request.IdTarefa);
            if (tarefa == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Tarefa", "a"));

            return tarefa;
        }
        private async Task<Usuario> ObterUsuarioAsync(IncluirComentarioTarefaRequest request)
        {
            var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
            if (usuario == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Usuario", "o"));

            return usuario;
        }
    }
}
