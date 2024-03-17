using Asp.Versioning;
using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios;
using Desafio.EclipseWorks.TaskManager.Api.Filters;

namespace Desafio.EclipseWorks.TaskManager.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioDesempenhoAppService _RelatorioDesempenhoAppService;

        public RelatoriosController(IRelatorioDesempenhoAppService relatorioDesempenhoAppService)
        {
            _RelatorioDesempenhoAppService = relatorioDesempenhoAppService;
        }

        [HttpGet("Desempenho")]
        [SwaggerOperation(Summary = "Relatorio gerencial")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        [AcessoGerencial]
        public async Task<IActionResult> BuscarInformacoesDesempenho([FromHeader] string idUsuario)
        {
            return Ok(await _RelatorioDesempenhoAppService.ExecutarAsync());
        }
    }
}
