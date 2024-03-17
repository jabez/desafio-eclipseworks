using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities;
using FluentAssertions;

namespace Desafio.EclipseWorks.TaskManager.Tests.Domain.Entities
{
    public class ComentarioTests
    {
        [Fact(DisplayName = "Deve criar um comentario de acordo com o parametros de entrada")]
        public void Criar_QuandoExecutado_DeveCriarUmComentarioDeAcordoParametrosEntrada()
        {
            //Arrange
            var faker = new Faker("pt_BR");
            var descricao = faker.Random.String2(25);
            var usuario = UsuarioFake.Criar();
            var tarefa = TarefaFake.Criar();

            //Act
            var comentario = Comentario.Criar(descricao, usuario, tarefa) ;

            //Assert
            comentario.Should().NotBeNull();
            comentario.Id.ToString().Should().NotBeEmpty();
            comentario.Descricao.Should().Be(descricao);
        }
    }
}
