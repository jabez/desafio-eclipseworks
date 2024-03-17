using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities
{
    public class ComentarioFake
    {

        public static Comentario Criar(Usuario usuario)
        {
            var faker = new Faker("pt_BR");
            var descricao = faker.Random.String2(25);
            var tarefa = TarefaFake.Criar();

            return Comentario.Criar(descricao, usuario, tarefa);
        }
    }
}
