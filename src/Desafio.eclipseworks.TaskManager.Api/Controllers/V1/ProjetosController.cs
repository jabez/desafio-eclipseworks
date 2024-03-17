using Asp.Versioning;
using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario.Dto;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria.Dtos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.EclipseWorks.TaskManager.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ICriaProjetoAppService _criaProjetoAppService;
        private readonly IBuscaProjetoPorUsuarioAppService _buscaProjetoPorUsuarioAppService;
        private readonly IRemoveProjetoAppService _removeProjetoAppService;

        public ProjetosController(ICriaProjetoAppService criaProjetoAppService, 
                                  IBuscaProjetoPorUsuarioAppService buscaProjetoPorUsuarioAppService,
                                  IRemoveProjetoAppService removeProjetoAppService)
        {
            _criaProjetoAppService = criaProjetoAppService;
            _buscaProjetoPorUsuarioAppService = buscaProjetoPorUsuarioAppService;
            _removeProjetoAppService = removeProjetoAppService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo projeto")]
        [SwaggerResponse(StatusCodes.Status201Created, "Projeto criado", typeof(Retorno<CriaProjetoResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> CriarProjeto([FromBody] CriaProjetoRequest request)
        {
            return Created("", await _criaProjetoAppService.ExecutarAsync(request));
        }

        [HttpGet("usuario/{idUsuario:guid}")]
        [SwaggerOperation(Summary = "lista todos os projetos do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso", typeof(Retorno<List<BuscaProjetoPorUsuarioResponse>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> BuscaProjetoPorUsuario([FromRoute] BuscaProjetoPorUsuarioRequest request)
        {
            return Ok(await _buscaProjetoPorUsuarioAppService.ExecutarAsync(request));
        }

        [HttpDelete("{idProjeto:Guid}")]
        [SwaggerOperation(Summary = "Remover projeto")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> RemoverProjeto([FromRoute] Guid idProjeto)
        {
            await _removeProjetoAppService.ExecutarAsync(new RemoveProjetoRequest(idProjeto));
            return NoContent();
        }
    }
}
