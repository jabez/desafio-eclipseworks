using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities
{
    public class TarefaFake
    {
        public static Tarefa Criar()
        {
            var faker = new Faker("pt_BR");
            var titulo = faker.Random.String2(20);
            var descricao = faker.Random.String2(20);
            var dataVencimento = DateTime.UtcNow;
            var prioridade = faker.PickRandom<Prioridade>();
            var idUsuario = UsuarioFake.Criar().Id;
            var projeto = ProjetoFake.Criar();


            return Tarefa.Criar(titulo, descricao, dataVencimento, prioridade, idUsuario, projeto);
        }
    }
}
