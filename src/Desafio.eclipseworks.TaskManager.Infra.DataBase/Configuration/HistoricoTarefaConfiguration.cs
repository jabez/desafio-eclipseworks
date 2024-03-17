namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration
{
    using Desafio.EclipseWorks.TaskManager.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HistoricoTarefaConfiguration : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.CampoAlterado).IsRequired();
            builder.Property(h => h.ValorAntigo).IsRequired();
            builder.Property(h => h.NovoValor).IsRequired();
        }
    }
}
