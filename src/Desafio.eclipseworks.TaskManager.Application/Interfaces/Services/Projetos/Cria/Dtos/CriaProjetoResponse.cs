namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.Cria.Dtos
{
    public class CriaProjetoResponse
    {
        public CriaProjetoResponse(string idProjeto, string titulo, string descricao)
        {
            IdProjeto = idProjeto;
            Titulo = titulo;
            Descricao = descricao;
        }

        public string IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }
}
