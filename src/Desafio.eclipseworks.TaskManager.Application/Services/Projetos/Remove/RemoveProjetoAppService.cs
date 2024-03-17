using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.Remove
{
    public class RemoveProjetoAppService : IRemoveProjetoAppService
    {
        private readonly IProjetoRepository _projetoRepository;

        public RemoveProjetoAppService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task ExecutarAsync(RemoveProjetoRequest request)
        {
            var projeto = await ObterProjetoAsync(request);
            projeto.InativarProjeto();
            await _projetoRepository.AtualizarAsync(projeto);
        }

        private async Task<Projeto> ObterProjetoAsync(RemoveProjetoRequest request)
        {
            var projeto = await _projetoRepository.ObterAsync(request.IdProjeto);
            if (projeto == null)
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado, "projeto", "o"));

            return projeto;
        }
    }
}
