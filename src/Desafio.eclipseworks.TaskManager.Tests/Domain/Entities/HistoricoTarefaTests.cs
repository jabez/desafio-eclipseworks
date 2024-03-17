using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities;
using FluentAssertions;

namespace Desafio.EclipseWorks.TaskManager.Tests.Domain.Entities
{
    public class HistoricoTarefaTests
    {
        [Fact(DisplayName = "Deve criar um Historico de Tarefa de acordo com o parametros de entrada")]
        public void Criar_QuandoExecutado_DeveCriarUmHistoricoDeTarefaDeAcordoParametrosEntrada()
        {
            //Arrange
            var faker = new Faker("pt_BR");
            var campoAlterado = faker.Random.String2(10);
            var valorAntigo = faker.Random.String2(10);
            var novoValor = faker.Random.String2(10);
            var usuario = UsuarioFake.Criar();
            var tarefa = TarefaFake.Criar();

            //Act
            var historicoTarefa = HistoricoTarefa.Criar(campoAlterado, novoValor, valorAntigo, usuario, tarefa);

            //Assert
            historicoTarefa.Should().NotBeNull();
            historicoTarefa.Id.ToString().Should().NotBeEmpty();
            historicoTarefa.DataModificacao.Should().BeAfter(default);
            historicoTarefa.CampoAlterado.Should().Be(campoAlterado);
            historicoTarefa.ValorAntigo.Should().Be(valorAntigo);
            historicoTarefa.NovoValor.Should().Be(novoValor);
            historicoTarefa.NomeUsuarioAlteracao.Should().Be(usuario.Nome);
            historicoTarefa.IdUsuarioAlteracao.Should().Be(usuario.Id);
        }
    }
}
