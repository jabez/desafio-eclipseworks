namespace Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions
{
    public class UsuarioNaoAutorizadoException : Exception
    {
        public IEnumerable<string> MensagensErro { get; }

        public UsuarioNaoAutorizadoException(string mensagem) : base(mensagem)
        {
            MensagensErro = new List<string>() { };
        }

        public UsuarioNaoAutorizadoException(IEnumerable<string> mensagens) : base(string.Join(';', mensagens))
        {
            MensagensErro = mensagens;
        }
    }
}
