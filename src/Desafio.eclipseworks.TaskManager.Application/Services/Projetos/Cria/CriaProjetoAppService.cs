using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Projetos.Cria
{
    public class CriaProjetoAppService : ICriaProjetoAppService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CriaProjetoAppService(IProjetoRepository projetoRepository, IUsuarioRepository usuarioRepository)
        {
            _projetoRepository = projetoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Retorno<CriaProjetoResponse>> ExecutarAsync(CriaProjetoRequest request)
        {
            var usuario = await _usuarioRepository.ObterAsync(request.IdUsuario);
            if (usuario == null)
                throw new ArgumentException(string.Format(MensagemValidacao.CampoInvalido, nameof(request.IdUsuario)));

            var projeto = Projeto.Criar(request.Titulo, request.Descricao, usuario);
            await _projetoRepository.AdicionarAsync(projeto);
            return CriarResponse(projeto);
        }

        private static Retorno<CriaProjetoResponse> CriarResponse(Projeto projeto)
        {
            return new Retorno<CriaProjetoResponse>()
            {
                Sucesso = true,
                Dados = new CriaProjetoResponse(projeto.Id.ToString(), projeto.Titulo, projeto.Descricao)
            };
        }
    }
}
