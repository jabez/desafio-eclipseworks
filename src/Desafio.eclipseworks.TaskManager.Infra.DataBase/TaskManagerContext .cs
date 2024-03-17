using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Infra.DataBase.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase
{
    public class TaskManagerContext : DbContext
    {
        protected TaskManagerContext()
        {
        }

        public TaskManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<HistoricoTarefa> HistoricosTarefa { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           new UsuarioConfiguration().Configure(modelBuilder.Entity<Usuario>());
           new TarefaConfiguration().Configure(modelBuilder.Entity<Tarefa>());
           new ProjetoConfiguration().Configure(modelBuilder.Entity<Projeto>());
           new HistoricoTarefaConfiguration().Configure(modelBuilder.Entity<HistoricoTarefa>());
           new ComentarioConfiguration().Configure(modelBuilder.Entity<Comentario>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
