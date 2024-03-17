using Desafio.eclipseworks.TaskManager.Application.Models.Retornos;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using System.Net;

namespace Desafio.eclipseworks.TaskManager.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = exception switch
            {
                RegraDeNegocioException regraDeNegocioException => ExceptionResponse(regraDeNegocioException?.Message, "Erro de negocio", (int)HttpStatusCode.UnprocessableEntity),
                ArgumentException argumentException => ExceptionResponse(argumentException?.Message, "Parametro de entrada invalido", (int)HttpStatusCode.BadRequest),
                RecursoNaoEncontradoException recursoNaoEncontradoException => ExceptionResponse(recursoNaoEncontradoException?.Message, "Recurso não encontrado", (int)HttpStatusCode.BadRequest),
                UsuarioNaoAutorizadoException usuarioNaoAutorizadoException => ExceptionResponse(usuarioNaoAutorizadoException?.Message, "Acesso negado", (int)HttpStatusCode.Unauthorized),
                _ => ExceptionResponse(exception?.Message, "Erro ao executar operação", (int)HttpStatusCode.InternalServerError),
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)result.statusCode;
            string json = System.Text.Json.JsonSerializer.Serialize(result.retorno);
            return context.Response.WriteAsync(json);
        }

        private dynamic ExceptionResponse(string exceptionMessage, string mensagemPadrao, int statusCode) => new
        {
            statusCode,
            retorno = new Retorno<ErroResponse>()
            {
                Sucesso = false,
                Mensagem = mensagemPadrao,
                Dados = new ErroResponse()
                {
                    Detalhe = exceptionMessage
                }
            }
        };
    }
}
