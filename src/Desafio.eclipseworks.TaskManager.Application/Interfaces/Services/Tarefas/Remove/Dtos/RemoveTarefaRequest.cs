namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Tarefas.Remove.Dtos
{
    public class RemoveTarefaRequest
    {
        public RemoveTarefaRequest(int idTarefa, Guid idUsuario)
        {
            IdTarefa = idTarefa;
            IdUsuario = idUsuario;
        }

        public int IdTarefa { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
