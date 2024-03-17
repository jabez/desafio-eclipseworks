using Asp.Versioning;
using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.EclipseWorks.TaskManager.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IBuscaTodosUsuariosAppService _buscaTodosUsuariosAppService;

        public UsuariosController(IBuscaTodosUsuariosAppService buscaTodosUsuariosAppService)
        {
            _buscaTodosUsuariosAppService = buscaTodosUsuariosAppService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos os usuarios")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso", typeof(Retorno<List<BuscaTodosUsuariosResponse>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> BuscarTodosUsuarios([FromQuery] BuscaTodosUsuariosRequest request)
        {
            return Ok(await _buscaTodosUsuariosAppService.ExecutarAsync(request));
        }

    }
}
