namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration
{
    using Desafio.EclipseWorks.TaskManager.Domain.common.Enum;
    using Desafio.EclipseWorks.TaskManager.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Perfil).HasConversion<int>();

            builder.HasMany(u => u.Projetos)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey(p => p.IdUsuario)
                   .HasPrincipalKey(p => p.Id);

            builder.HasData(Usuario.Criar("usuario comum", Perfil.Usuario), Usuario.Criar("usuario gerente", Perfil.Gerente));
        }
    }

}
