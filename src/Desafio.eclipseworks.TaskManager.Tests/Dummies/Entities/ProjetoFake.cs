using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities
{
    public class ProjetoFake
    {
        public static Projeto Criar()
        {
            var faker = new Faker("pt_BR");
            var titulo = faker.Random.String2(20);
            var descricao = faker.Random.String2(20);
            var Usuario = UsuarioFake.Criar();

            return Projeto.Criar(titulo,descricao, Usuario);
        }

        public static Projeto CriarProjetoComTarefaVinculada(int quantidadeTarefas)
        {
            var faker = new Faker("pt_BR");
            var titulo = faker.Random.String2(20);
            var descricao = faker.Random.String2(20);
            var Usuario = UsuarioFake.Criar();

            var projeto = Projeto.Criar(titulo, descricao, Usuario);

            for (int i = 0; i < quantidadeTarefas; i++)
            {
                projeto.IncluirTarefa(TarefaFake.Criar());
            }

            return projeto;
        }
    }
}
