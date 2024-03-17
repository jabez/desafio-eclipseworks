using Bogus;
using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Tests.Dummies.Entities
{
    public static class UsuarioFake
    {
        public static Usuario Criar()
        {
            var faker = new Faker("pt_BR");
            return Usuario.Criar(faker.Person.FullName, faker.PickRandom<Perfil>());
        }
    }
}
