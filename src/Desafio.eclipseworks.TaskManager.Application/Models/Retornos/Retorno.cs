namespace Desafio.eclipseworks.TaskManager.Application.Models.Retornos
{
    public class Retorno<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }

        public Retorno(T dados, bool sucesso = true)
        {
            Dados = dados;
            Sucesso = sucesso;
        }

        public Retorno()
        {
        }
    }
}
