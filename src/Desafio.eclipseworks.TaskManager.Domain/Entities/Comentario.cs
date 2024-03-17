namespace Desafio.EclipseWorks.TaskManager.Domain.Entities
{
    public class Comentario
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCricao { get; private set; }

        public Guid IdUsuario { get; private set; }

        public int IdTarefa { get; private set; }
        public Tarefa Tarefa { get; private set; }

        protected Comentario() { }

        protected Comentario(string descricao, Usuario usuario, Tarefa tarefa)
        {
            Id = Guid.NewGuid();
            DataCricao = DateTime.UtcNow;
            Descricao = descricao;
            IdUsuario = usuario.Id;
            IdTarefa = tarefa.Id;
            Tarefa = tarefa;
            
        }

        public static Comentario Criar(string descricao, Usuario usuario, Tarefa tarefa) => new (descricao, usuario, tarefa);
    }
}
