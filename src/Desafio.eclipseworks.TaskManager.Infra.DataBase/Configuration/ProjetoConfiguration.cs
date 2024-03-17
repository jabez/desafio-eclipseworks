using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.HasMany(p => p.Tarefas)
                   .WithOne(p=> p.Projeto)
                   .HasForeignKey(t => t.IdProjeto)
                   .HasPrincipalKey(p => p.Id);
        }
    }

}
