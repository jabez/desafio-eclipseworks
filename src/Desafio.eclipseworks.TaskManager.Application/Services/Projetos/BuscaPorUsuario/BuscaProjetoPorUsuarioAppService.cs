using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario.Dto;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.BuscaPorUsuario
{
    public class BuscaProjetoPorUsuarioAppService : IBuscaProjetoPorUsuarioAppService
    {
        private readonly IProjetoRepository _projetoRepository;

        public BuscaProjetoPorUsuarioAppService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<Retorno<List<BuscaProjetoPorUsuarioResponse>>> ExecutarAsync(BuscaProjetoPorUsuarioRequest request)
        {
            var projetos = await _projetoRepository.Where(x => x.IdUsuario == request.IdUsuario && x.Ativo == true);
            if (!projetos.Any())
                throw new RecursoNaoEncontradoException(string.Format(MensagemValidacao.RecursoNaoEncontrado,"Projeto","a"));

            return new Retorno<List<BuscaProjetoPorUsuarioResponse>>()
            {
                Sucesso = true,
                Dados = projetos.ToList().Select(x => new BuscaProjetoPorUsuarioResponse(x.Id.ToString(), x.Titulo, x.Descricao)).ToList(),
            };
        }
    }
}
