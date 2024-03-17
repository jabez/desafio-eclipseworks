using Asp.Versioning;
using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.BuscaPorProjeto.Dto;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria.Dtos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita.Dtos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario.Dtos;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove;
using Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove.Dtos;
using Desafio.EclipseWorks.TaskManager.Application.Services.Tarefas.IncluirComentarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Desafio.EclipseWorks.TaskManager.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ICriaTarefaAppService _criaTarefaAppService;
        private readonly IBuscaTarefaPorProjetoAppService _buscaTarefaPorProjetoAppService;
        private readonly IEditaTarefaAppService _editaTarefaAppService;
        private readonly IRemoveTarefaAppService _removeTarefaAppService;
        private readonly IIncluirComentarioTarefaAppService _incluirComentarioTarefaAppService;

        public TarefasController(ICriaTarefaAppService criaTarefaAppService, 
                                 IBuscaTarefaPorProjetoAppService buscaTarefaPorProjetoAppService, 
                                 IEditaTarefaAppService editaTarefaAppService, 
                                 IRemoveTarefaAppService removeTarefaAppService,
                                 IIncluirComentarioTarefaAppService incluirComentarioTarefaAppService)
        {
            _criaTarefaAppService = criaTarefaAppService;
            _buscaTarefaPorProjetoAppService = buscaTarefaPorProjetoAppService;
            _editaTarefaAppService = editaTarefaAppService;
            _removeTarefaAppService = removeTarefaAppService;
            _incluirComentarioTarefaAppService = incluirComentarioTarefaAppService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicioanar uma nova tarefa a um projeto")]
        [SwaggerResponse(StatusCodes.Status201Created, "Tarefa criado", typeof(Retorno<CriaTarefaResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> CriarTarefa([FromBody] CriaTarefaRequest request)
        {
            return Created("", await _criaTarefaAppService.ExecutarAsync(request));
        }

        [HttpGet("projeto/{idProjeto:guid}")]
        [SwaggerOperation(Summary = "Lista todas as tarefas de um projeto")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso", typeof(Retorno<List<BuscaTarefaPorProjetoResponse>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> BuscaTarefaPorProjeto([FromRoute] BuscaTarefaPorProjetoRequest request)
        {
            return Ok(await _buscaTarefaPorProjetoAppService.ExecutarAsync(request));
        }

        [HttpPut("{idTarefa:int}")]
        [SwaggerOperation(Summary = "Editar tarefas")]
        [SwaggerResponse(StatusCodes.Status200OK, "Operação realizada com sucesso", typeof(Retorno<List<EditaTarefaResponse>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> EditarTarefa([FromBody] EditaTarefaRequest request, int idTarefa)
        {
            request.IdTarefa = idTarefa;

            return Ok(await _editaTarefaAppService.ExecutarAsync(request));
        }

        [HttpDelete("{idTarefa:int}")]
        [SwaggerOperation(Summary = "Remover tarefas")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Operação realizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> RemoverTarefas([FromRoute] int idTarefa, [FromHeader] Guid idUsuario)
        {

            await _removeTarefaAppService.ExecutarAsync(new RemoveTarefaRequest(idTarefa, idUsuario));

            return NoContent();
        }

        [HttpPost("{idTarefa:int}/comentarios")]
        [SwaggerOperation(Summary = "Adicioanar um comentario a uma tarefa")]
        [SwaggerResponse(StatusCodes.Status201Created, "Comentario criado", typeof(Retorno<IncluirComentarioTarefaResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Parametro de entrada invalido", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Erro de negocio", typeof(Retorno<ErroResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(Retorno<ErroResponse>))]
        public async Task<IActionResult> IncluirComentario([FromBody] IncluirComentarioTarefaRequest request, [FromRoute] int idTarefa)
        {
            request.IdTarefa = idTarefa;
            return Created("", await _incluirComentarioTarefaAppService.ExecutarAsync(request));
        }
    }
}
