using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.Cria
{
    public class CriaTarefaAppService : ICriaTarefaAppService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CriaTarefaAppService(IProjetoRepository projetoRepository, ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
        {
            _projetoRepository = projetoRepository;
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Retorno<CriaTarefaResponse>> ExecutarAsync(CriaTarefaRequest request)
        {
            var projeto = await ObterProjetoAsync(request);
            var usuario = await ObterUsuarioAsync(request);
            var tarefa = Tarefa.Criar(request.Titulo, request.Descricao, request.DataVencimento, request.Prioridade, usuario.Id, projeto);
            projeto.IncluirTarefa(tarefa);

            await _projetoRepository.AtualizarAsync(projeto);

            return new Retorno<CriaTarefaResponse>()
            {
                Sucesso = true,
                Dados = new CriaTarefaResponse()
                {
                    Idtarefa = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    DataVencimento = tarefa.DataVencimento,
                    Prioridade = tarefa.Prioridade,
                    Status = tarefa.Status,
                    IdUsuario = tarefa.IdUsuario,
                    IdProjeto = tarefa.IdProjeto
                }
            };
        }

        private async Task<Usuario> ObterUsuarioAsync(CriaTarefaRequest request)
        {
            var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
            if (usuario == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "Usuario", "o"));

            return usuario;
        }

        private async Task<Projeto> ObterProjetoAsync(CriaTarefaRequest request)
        {
            var projeto = await _projetoRepository.ObterAsync(request.IdProjeto);
            if (projeto == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "projeto", "o"));

            return projeto;
        }
    }
}
