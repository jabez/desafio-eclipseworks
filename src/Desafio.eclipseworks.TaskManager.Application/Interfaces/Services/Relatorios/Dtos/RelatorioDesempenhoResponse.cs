namespace Desafio.EclipseWorks.TaskManager.Application.Interfaces.Services.Relatorios.Dtos
{
    public class RelatorioDesempenhoResponse
    {
        public RelatorioDesempenhoResponse(string nome, int quantidadeTarefasConcluidas)
        {
            Nome = nome;
            QuantidadeTarefasConcluidas = quantidadeTarefasConcluidas;
        }

        public string Nome { get; set; }
        public int QuantidadeTarefasConcluidas { get; set; }
    }
}
