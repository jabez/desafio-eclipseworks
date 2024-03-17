using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Cria.Dtos
{
    public class CriaTarefaResponse
    {
        public int Idtarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdProjeto { get; set; }
    }
}
