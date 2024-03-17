using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria.Dtos
{
    public class CriaTarefaRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Prioridade Prioridade { get; set; }
        public Guid IdUsuario {  get; set; }
        public Guid IdProjeto { get; set; }
    }
}
