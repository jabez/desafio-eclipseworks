using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.common.Constants;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.common.Exceptions;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities;
using FluentAssertions;

namespace Desafio.EclipseWorks.TaskManager.Tests.Domain.Entities
{
    public class ProjetoTests
    {
        [Fact(DisplayName = "Deve criar um projeto de acordo com o parametros de entrada")]
        public void Criar_QuandoExecutado_DeveCriarUmProjetoDeAcordoParametrosEntrada()
        {
            //Arrange
            var faker = new Faker("pt_BR");
            var titulo = faker.Random.String2(20);
            var descricao = faker.Random.String2(20);
            var usuario = UsuarioFake.Criar();

            //Act
            var projeto = Projeto.Criar(titulo, descricao, usuario);

            //Assert
            projeto.Should().NotBeNull();
            projeto.Id.ToString().Should().NotBeEmpty();
            projeto.Titulo.Should().Be(titulo);
            projeto.Descricao.Should().Be(descricao);
        }

        [Fact(DisplayName = "Deve permitir incluir uma tarefa no projeto")]
        public void IncluirTarefa_QuandoIncluidoUmaNovaTarefa_DevePermitirInclusao()
        {
            //Arrange
            var projeto = ProjetoFake.Criar();
            var tarefa = TarefaFake.Criar();

            //Act
            projeto.IncluirTarefa(tarefa);

            //Assert
            projeto.Tarefas.Any().Should().BeTrue();
            projeto.Tarefas.First().Titulo.Should().Be(tarefa.Titulo);
        }

        [Fact(DisplayName = "Deve bloquear a inclusão de uma nova tarefa quando o projeto atingiu o limite maximo permitido")]
        public void IncluirTarefa_QuandoIncluidoUmaNovaTarefaELimiteMaximoAtingido_DeveRetornarException()
        {
            //Arrange
            var projeto = ProjetoFake.CriarProjetoComTarefaVinculada(20);
            var tarefa = TarefaFake.Criar();

            //Act
            Action action = () => projeto.IncluirTarefa(tarefa);

            //Assert
            action.Should().Throw<RegraDeNegocioException>().WithMessage(MensagemValidacao.LimiteTarefaPorProjeto);
        }

        [Fact(DisplayName = "Deve inativar projeto")]
        public void InativarProjeto_QuandoExecutado_DeveInativarProjeto()
        {
            //Arrange
            var projeto = ProjetoFake.CriarProjetoComTarefaVinculada(1);
            var usuario = UsuarioFake.Criar();

            projeto.Tarefas.First().AtualizarStatus(Status.EmAndamento, usuario);

            //Act
             projeto.InativarProjeto();

            //Assert
            projeto.Ativo.Should().BeFalse();
        }

        [Fact(DisplayName = "Nao Deve permitir inativar projeto com tarefas pendentes")]
        public void InativarProjeto_QuandoProjetoPossuirTarefaPendente_NaoDeveRetornarException()
        {
            //Arrange
            var projeto = ProjetoFake.CriarProjetoComTarefaVinculada(20);

            //Act
            Action action = () => projeto.InativarProjeto();


            //Assert
            action.Should().Throw<RegraDeNegocioException>().WithMessage(MensagemValidacao.ValidacaoExclusaoProjetoComTarefasPendentes);
        }
    }
}
