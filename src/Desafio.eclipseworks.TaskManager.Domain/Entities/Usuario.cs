using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;

namespace Desafio.EclipseWorks.TaskManager.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get;  private set; }
        public Perfil Perfil { get; private set; }

        public ICollection<Projeto> Projetos { get; private set; } = [];
        public ICollection<Comentario> Comentarios { get; private set; } = [];
        

        protected Usuario(string nome, Perfil perfil) 
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Perfil = perfil;
        }

        public static Usuario Criar(string nome, Perfil perfil) => new(nome, perfil);

        public Usuario IncluirProjeto(Projeto projeto)
        {
            Projetos.Add(projeto);

            return this;
        }
    }
}
