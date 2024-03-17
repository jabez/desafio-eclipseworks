namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration
{
    using Desafio.EclipseWorks.TaskManager.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Titulo).IsRequired();
            builder.Property(t => t.Descricao).IsRequired();
            builder.Property(t => t.Status).HasConversion<int>();
            builder.Property(t => t.Prioridade).HasConversion<int>();

            builder.HasMany(t => t.Comentarios)
                   .WithOne(c => c.Tarefa)
                   .HasForeignKey(c => c.IdTarefa)
                   .HasPrincipalKey(t => t.Id);

            builder.HasMany(t => t.Historicos)
                   .WithOne(h => h.Tarefa)
                   .HasForeignKey(h => h.IdTarefa)
                   .HasPrincipalKey(t => t.Id);
        }
    }
}
