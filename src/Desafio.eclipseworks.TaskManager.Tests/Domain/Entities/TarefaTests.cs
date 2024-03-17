using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities;
using FluentAssertions;

namespace Desafio.EclipseWorks.TaskManager.Tests.Domain.Entities
{
    public class TarefaTests
    {
        [Fact(DisplayName = "Deve criar uma Task de acordo com o parametros de entrada")]
        public void Criar_QuandoExecutado_DeveCriarUmaTaskDeAcordoParametrosEntrada()
        {
            //Arrange
            var faker = new Faker("pt_BR");
            var titulo = faker.Random.String2(20);
            var descricao = faker.Random.String2(20);
            var dataVencimento = DateTime.UtcNow;
            var prioridade = faker.PickRandom<Prioridade>();
            var idUsuario = UsuarioFake.Criar().Id;
            var projeto = ProjetoFake.Criar();

            //Act
            var tarefa = Tarefa.Criar(titulo, descricao, dataVencimento, prioridade, idUsuario,projeto);

            //Assert
            tarefa.Should().NotBeNull();
            tarefa.Id.ToString().Should().NotBeEmpty();
            tarefa.Titulo.Should().Be(titulo);
            tarefa.Descricao.Should().Be(descricao);
            tarefa.DataVencimento.Should().Be(dataVencimento);
            tarefa.Prioridade.Should().Be(prioridade);
            tarefa.IdUsuario.Should().Be(idUsuario);
        }

        [Fact(DisplayName = "Deve Atualizar titulo da tarefa")]
        public void AtualizarTitulo_QuandoExecutado_DeveAlterarTituloTarefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var novoTitulo = "novo titulo";

            //Act
            tarefa.AtualizarTitulo(novoTitulo,usuarioAlteracao);

            //Assert
            tarefa.Titulo.Should().Be(novoTitulo);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("titulo");
            tarefa.Historicos.First().NovoValor.Should().Be(novoTitulo);
        }

        [Fact(DisplayName = "Nao deve atualizar titulo se o valor for igual ao antigo")]
        public void AtualizarTitulo_QuandoTituloNovoEAntigoIgual_NaoDeveRealizarAlteracao()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var tituloAntigo = tarefa.Titulo;
            var novoTitulo = tituloAntigo;
            

            //Act
            tarefa.AtualizarTitulo(novoTitulo, usuarioAlteracao);

            //Assert
            tarefa.Titulo.Should().Be(tituloAntigo);
            tarefa.Historicos.Count().Should().Be(0);
        }

        [Fact(DisplayName = "Deve atualizar descricao da tarefa")]
        public void AtualizarDescricao_QuandoExecutado_DeveAlterarDescricaoTarefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var novaDescricao = "nova descricao";

            //Act
            tarefa.AtualizarDescricao(novaDescricao, usuarioAlteracao);

            //Assert
            tarefa.Descricao.Should().Be(novaDescricao);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("descricao");
            tarefa.Historicos.First().NovoValor.Should().Be(novaDescricao);
        }

        [Fact(DisplayName = "Nao deve atualizar descricao se o valor for igual ao antigo")]
        public void AtualizarDescricao_QuandoDescricaoNovoEAntigoIgual_NaoDeveRealizarAlteracao()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var descricaoAntiga = tarefa.Descricao;
            var descricaoNova = descricaoAntiga;


            //Act
            tarefa.AtualizarDescricao(descricaoNova, usuarioAlteracao);

            //Assert
            tarefa.Descricao.Should().Be(descricaoAntiga);
            tarefa.Historicos.Count().Should().Be(0);
        }

        [Fact(DisplayName = "Deve atualizar vencimento da tarefa")]
        public void AtualizarVencimento_QuandoExecutado_DeveAlterarDescricaoTarefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var novoVencimento = DateTime.UtcNow.AddDays(1);

            //Act
            tarefa.AtualizarDataVencimento(novoVencimento, usuarioAlteracao);

            //Assert
            tarefa.DataVencimento.Should().Be(novoVencimento);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("dataVencimento");
            tarefa.Historicos.First().NovoValor.Should().Be(novoVencimento.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
        }

        [Fact(DisplayName = "Nao deve atualizar vencimento se o valor for igual ao antigo")]
        public void AtualizarVencimento_QuandoVencimentoNovoEAntigoIgual_NaoDeveRealizarAlteracao()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var vencimentoAntigo = tarefa.DataVencimento;
            var novoVencimento = vencimentoAntigo;


            //Act
            tarefa.AtualizarDataVencimento(novoVencimento, usuarioAlteracao);

            //Assert
            tarefa.DataVencimento.Should().Be(vencimentoAntigo);
            tarefa.Historicos.Count().Should().Be(0);
        }

        [Fact(DisplayName = "Deve atualizar status da tarefa")]
        public void AtualizarStatus_QuandoExecutado_DeveAlterarDescricaoTarefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var novoStatus = Status.EmAndamento;


            //Act
            tarefa.AtualizarStatus(novoStatus, usuarioAlteracao);

            //Assert
            tarefa.Status.Should().Be(novoStatus);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("status");
            tarefa.Historicos.First().NovoValor.Should().Be(novoStatus.ToString());
        }

        [Fact(DisplayName = "Nao deve atualizar status se o valor for igual ao antigo")]
        public void AtualizarStatus_QuandoStatusNovoEAntigoIgual_NaoDeveRealizarAlteracao()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();
            var statusAntigo = tarefa.Status;
            var novoStatus = statusAntigo;


            //Act
            tarefa.AtualizarStatus(novoStatus, usuarioAlteracao);

            //Assert
            tarefa.Status.Should().Be(statusAntigo);
            tarefa.Historicos.Count().Should().Be(0);
        }

        [Fact(DisplayName = "Deve inativar uma tarefa")]
        public void InativarTarefa_QuandoExecutadoComSucesso_DeveInativarTarefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuarioAlteracao = UsuarioFake.Criar();


            //Act
            tarefa.InativarTarefa(usuarioAlteracao);

            //Assert
            tarefa.Ativa.Should().Be(false);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("ativa");
        }

        [Fact(DisplayName = "Deve incluir um comentario na tarefa")]
        public void IncluirComentario_QuandoExecutado_DeveIncluirComentarioNaTerefa()
        {
            //Arrange
            var tarefa = TarefaFake.Criar();
            var usuario = UsuarioFake.Criar();
            var comentario = ComentarioFake.Criar(usuario);

            //Act
            tarefa.IncluirComentario(comentario, usuario);

            //Assert
            tarefa.Comentarios.Count().Should().BeGreaterThan(0);
            tarefa.Comentarios.First().Descricao.Should().Be(comentario.Descricao);
            tarefa.Historicos.Count().Should().BeGreaterThan(0);
            tarefa.Historicos.First().CampoAlterado.Should().Be("comentario");
        }
    }
}
