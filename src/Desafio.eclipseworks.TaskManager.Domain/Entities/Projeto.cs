using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;

namespace Desafio.EclipseWorks.TaskManager.Domain.Entities
{
    public class Projeto
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<Tarefa> Tarefas { get; private set; } = [];

        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }

        protected Projeto()
        {
            
        }
        protected Projeto(string titulo, string descriaco,Usuario usuario) 
        {
            Id = Guid.NewGuid();
            Ativo = true;
            Titulo = titulo;
            Descricao = descriaco;
            Usuario = usuario;
        }

        public static Projeto Criar(string titulo, string descricao, Usuario usuario) => new (titulo, descricao, usuario);
        

        public Projeto IncluirTarefa(Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
            if (Tarefas.Count(x => x.Ativa) > 20)
                throw new RegraDeNegocioException(MensagemValidacao.LimiteTarefaPorProjeto);

            return this;
        }

        public void InativarProjeto()
        {
            if (Tarefas.Any(x => x.Status == Status.Pendente && x.Ativa == true))
                throw new RegraDeNegocioException(MensagemValidacao.ValidacaoExclusaoProjetoComTarefasPendentes);

            Ativo = false;
        }
    }
}
