namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria.Dtos
{
    public class CriaProjetoRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
