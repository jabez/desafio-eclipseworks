using System.Text.Json.Serialization;

namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.IncluiComentario.Dtos
{
    public class IncluirComentarioTarefaRequest
    {
        [JsonIgnore]
        public int IdTarefa { get; set; }
        public Guid IdUsuario { get; set; }
        public string Descricao { get; set; }
    }
}
