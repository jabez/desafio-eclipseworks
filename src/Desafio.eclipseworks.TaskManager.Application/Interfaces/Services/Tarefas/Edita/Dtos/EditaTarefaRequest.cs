using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using System.Text.Json.Serialization;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Edita.Dtos
{
    public class EditaTarefaRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Status Status { get; set; }
        [JsonIgnore]
        public int IdTarefa { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
