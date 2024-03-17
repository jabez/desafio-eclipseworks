using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Desafio.EclipseWorks.TaskManager.Api.Filters
{
    public class AcessoGerencialAttribute : TypeFilterAttribute
    {
        public AcessoGerencialAttribute() : base(typeof(AcessoGerencialFilter))
        {
        }
    }

    public class AcessoGerencialFilter : IAsyncActionFilter
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AcessoGerencialFilter(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("idUsuario", out var codigoUsuario))
            {
                var usuario = await _usuarioRepository.ObterAsync(new Guid(codigoUsuario));

                if (usuario == null || usuario.Perfil != Perfil.Gerente)
                {
                    throw new UsuarioNaoAutorizadoException("Usuario não autorizado");
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Usuario não informado");
                return;
            }

            await next();
        }
    }


}
