namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Usuarios.BuscaTodos.Dtos
{
    public class BuscaTodosUsuariosResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }

        public BuscaTodosUsuariosResponse(string id, string nome, string perfil)
        {
            Id = id;
            Nome = nome;
            Perfil = perfil;
        }
    }
}
