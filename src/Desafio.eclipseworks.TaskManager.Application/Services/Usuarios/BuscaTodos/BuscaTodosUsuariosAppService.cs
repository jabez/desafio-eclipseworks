using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos.Dtos;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;

namespace Desafio.EclipseWorks.TaskManager.Application.Services.Usuarios.BuscaTodos
{
    public class BuscaTodosUsuariosAppService : IBuscaTodosUsuariosAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public BuscaTodosUsuariosAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Retorno<List<BuscaTodosUsuariosResponse>>> ExecutarAsync(BuscaTodosUsuariosRequest request)
        {
            var usuarios = await _usuarioRepository.ObterTodosPaginadoAsync(Math.Max(1, request.PageSize), Math.Max(1, request.PageNumber));
            usuarios ??= [];

            return new Retorno<List<BuscaTodosUsuariosResponse>>()
            {
                Sucesso = true,
                Dados = usuarios.Select(x => new BuscaTodosUsuariosResponse(x.Id.ToString(), x.Nome, x.Perfil.ToString())).ToList()
            };
        }
    }
}
