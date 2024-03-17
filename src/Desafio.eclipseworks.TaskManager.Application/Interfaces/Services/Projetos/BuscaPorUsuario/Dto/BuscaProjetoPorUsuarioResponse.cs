namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Projetos.BuscaPorUsuario.Dto
{
    public class BuscaProjetoPorUsuarioResponse
    {
        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        public BuscaProjetoPorUsuarioResponse(string id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}
