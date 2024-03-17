namespace Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions
{
    public class RecursoNaoEncontradoException : Exception
    {
        public IEnumerable<string> MensagensErro { get; }

        public RecursoNaoEncontradoException(string mensagem) : base(mensagem)
        {
            MensagensErro = new List<string>() { };
        }

        public RecursoNaoEncontradoException(IEnumerable<string> mensagens) : base(string.Join(';', mensagens))
        {
            MensagensErro = mensagens;
        }
    }
}
