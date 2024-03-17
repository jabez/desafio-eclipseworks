using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities;
using FluentAssertions;

namespace Desafio.EclipseWorks.TaskManager.Tests.Domain.Entities
{
    public class UsuarioTests
    {
        [Fact(DisplayName = "Deve criar um usuário de acordo com o parametros de entrada")]
        public void Criar_QuandoExecutado_DeveCriarUmUsuarioDeAcordoParametrosEntrada()
        {
            //Arrange
            var faker = new Faker("pt_BR");
            var nome = faker.Person.FullName;
            var perfil = faker.PickRandom<Perfil>();

            //Act
            var usuario = Usuario.Criar(nome, perfil);

            //Assert
            usuario.Should().NotBeNull();
            usuario.Id.ToString().Should().NotBeEmpty();
            usuario.Perfil.Should().Be(perfil);
            usuario.Nome.Should().Be(nome);
        }

        [Fact(DisplayName = "Deve permitir incluir um projeto para o usuario")]
        public void IncluirProjeto_QuandoIncluidoUmNovoProjeto_DevePermitirInclusao()
        {
            //Arrange
            var usuario = UsuarioFake.Criar();
            var projeto = ProjetoFake.Criar();


            //Act
            usuario.IncluirProjeto(projeto);

            //Assert
            usuario.Projetos.Any().Should().BeTrue();
            usuario.Projetos.First().Id.Should().Be(projeto.Id);
        }
    }
}
