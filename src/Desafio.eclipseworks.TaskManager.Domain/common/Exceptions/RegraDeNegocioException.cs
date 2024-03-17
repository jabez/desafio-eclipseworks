namespace Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions
{
    public class RegraDeNegocioException : Exception
    {
        public IEnumerable<string> MensagensErro { get; }

        public RegraDeNegocioException(string mensagem) : base(mensagem)
        {
            MensagensErro = new List<string>() { };
        }

        public RegraDeNegocioException(IEnumerable<string> mensagens) : base(string.Join(';', mensagens))
        {
            MensagensErro = mensagens;
        }
    }
}
