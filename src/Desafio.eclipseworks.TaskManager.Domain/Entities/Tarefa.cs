using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;

namespace Desafio.EclipseWorks.TaskManager.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public Status Status { get; private set; }
        public Prioridade Prioridade { get; private set; }
        public bool Ativa { get; private set; }

        public Guid IdUsuario { get; private set; }

        public Guid IdProjeto { get; private set; }
        public Projeto Projeto { get; private set; }


        public ICollection<Comentario> Comentarios { get; private set; } = [];
        public ICollection<HistoricoTarefa> Historicos { get; private set; } = [];

        protected Tarefa()
        {

        }
        protected Tarefa(string titulo, string descricao, DateTime dataVencimento, Prioridade prioridade, Guid idUsuario, Projeto projeto)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Prioridade = prioridade;
            IdUsuario = idUsuario;
            Status = Status.Pendente;
            Projeto = projeto;
            Ativa = true;
        }

        public static Tarefa Criar(string titulo, string descricao, DateTime dataVencimento, Prioridade prioridade, Guid idUsuario, Projeto projeto) 
                => new(titulo, descricao, dataVencimento, prioridade, idUsuario, projeto);

        public Tarefa AtualizarTitulo( string novoTitulo, Usuario usuarioAlteracao)
        {
            if(string.IsNullOrEmpty(novoTitulo) || Titulo.Equals(novoTitulo)) 
                return this;

            IncluirHistorico("titulo", novoTitulo,Titulo, usuarioAlteracao);

            Titulo = novoTitulo;
            return this;
        }

        public Tarefa AtualizarDescricao(string novaDescricao, Usuario usuarioAlteracao)
        {
            if (string.IsNullOrEmpty(novaDescricao) || Descricao.Equals(novaDescricao))
                return this;

            IncluirHistorico("descricao", novaDescricao, Descricao, usuarioAlteracao);

            Descricao = novaDescricao;
            return this;
        }

        public Tarefa AtualizarDataVencimento(DateTime novaDataVencimento, Usuario usuarioAlteracao)
        {
            if (novaDataVencimento.Equals(default) || DataVencimento.Equals(novaDataVencimento))
                return this;

            IncluirHistorico("dataVencimento", 
                             novaDataVencimento.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                             DataVencimento.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                             usuarioAlteracao);

            DataVencimento = novaDataVencimento;
            return this;
        }
        
        public Tarefa AtualizarStatus(Status novoStatus, Usuario usuarioAlteracao)
        {
            if(Status.Equals(novoStatus)) return this;

            IncluirHistorico("status",
                             novoStatus.ToString(),
                             Status.ToString(),
                             usuarioAlteracao);
            Status = novoStatus;

            return this;
        }

        public void InativarTarefa(Usuario usuarioAlteracao)
        {
            var tarefaAtiva = false;
            IncluirHistorico("ativa",
                             tarefaAtiva.ToString(),
                             true.ToString(),
                             usuarioAlteracao);
            Ativa = tarefaAtiva;
        }

        private void IncluirHistorico(string campoAlterado, string novoValor, string valorAntigo, Usuario usuario)
        {
            var historicoTarefa = HistoricoTarefa.Criar(campoAlterado,novoValor, valorAntigo, usuario,this);
            Historicos.Add(historicoTarefa);
        }

        public void IncluirComentario(Comentario comentario, Usuario usuarioInclusao)
        {
            Comentarios.Add(comentario);
            IncluirHistorico("comentario", comentario.Descricao, "", usuarioInclusao) ;
        }
    }
}
