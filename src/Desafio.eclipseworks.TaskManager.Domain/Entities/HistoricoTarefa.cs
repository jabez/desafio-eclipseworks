namespace Desafio.EclipseWorks.TaskManager.Domain.Entities
{
    public class HistoricoTarefa
    {
        public Guid Id { get; private set; }
        public DateTime DataModificacao { get; private set; }
        public string CampoAlterado { get; private set; }
        public string ValorAntigo { get; private set; }
        public string NovoValor { get; private set; }

        public string NomeUsuarioAlteracao { get; private set; }
        public Guid IdUsuarioAlteracao { get; private set; }

        public int IdTarefa { get; private set; }
        public Tarefa Tarefa { get; private set; }

        protected HistoricoTarefa()
        {

        }

        protected HistoricoTarefa(string campoAlterado, string novoValor, string valorAntigo, Guid idUsuarioAlteracao, string nomeUsuarioAlteracao, Tarefa tarefa)
        {
             Id = Guid.NewGuid();
             CampoAlterado = campoAlterado;
             NovoValor = novoValor;
             ValorAntigo = valorAntigo;
             IdUsuarioAlteracao = idUsuarioAlteracao;
             NomeUsuarioAlteracao = nomeUsuarioAlteracao;
             DataModificacao = DateTime.UtcNow;
             Tarefa = tarefa;
        }

        public static HistoricoTarefa Criar(string campoAlterado, string novoValor, string valorAntigo, Usuario usuario, Tarefa tarefa)
        {
            return new HistoricoTarefa(campoAlterado,novoValor, valorAntigo, usuario.Id, usuario.Nome, tarefa);
        }
    }
}
