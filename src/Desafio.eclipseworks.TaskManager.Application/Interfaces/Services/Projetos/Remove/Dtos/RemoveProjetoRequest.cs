namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Remove.Dtos
{
    public class RemoveProjetoRequest
    {
        public RemoveProjetoRequest(Guid idProjeto)
        {
            IdProjeto = idProjeto;
        }

        public Guid IdProjeto { get; set; }
    }
}
