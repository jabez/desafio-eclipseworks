namespace Desafio.EclipseWorks.TaskManager.Domain.common.Constants
{
    public class MensagemValidacao
    {
        public const string LimiteTarefaPorProjeto = "O projeto deve ter no máximo de 20 tarefas";
        public const string ValidacaoExclusaoProjetoComTarefasPendentes = "Exclusão não permitida! para continuar realize a conclusão ou remoçao das tarefas pendentes";
        public const string CampoInvalido = "Campo {0} invalido";
        public const string RecursoNaoEncontrado = "{0} não encontrad{1}";
    }
}
