namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration
{
    using Desafio.EclipseWorks.TaskManager.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).IsRequired();
            builder.Property(c => c.DataCricao).IsRequired();
        }
    }
}
