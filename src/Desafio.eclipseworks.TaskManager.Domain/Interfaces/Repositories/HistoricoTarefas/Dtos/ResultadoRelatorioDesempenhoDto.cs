namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.HistoricoTarefas.Dtos
{
    public  class ResultadoRelatorioDesempenhoDto
    {
        public ResultadoRelatorioDesempenhoDto(string nome, int quantidadeTarefasConcluidas)
        {
            Nome = nome;
            QuantidadeTarefasConcluidas = quantidadeTarefasConcluidas;
        }

        public string Nome { get; set; }
        public int QuantidadeTarefasConcluidas { get; set; }
    }
}
