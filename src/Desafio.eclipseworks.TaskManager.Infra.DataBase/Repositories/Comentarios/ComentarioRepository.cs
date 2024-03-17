using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Comentarios;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Comentarios
{
    public class ComentarioRepository : IComentarioRepository
    {
        public readonly TaskManagerContext _taskManagerContext;

        public ComentarioRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public async Task AdicionarAsync(List<Comentario> comentarios)
        {
            await _taskManagerContext.Comentarios.AddRangeAsync(comentarios);
            await _taskManagerContext.SaveChangesAsync();
        }
    }
}
