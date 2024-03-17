using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Comentarios
{
    public interface IComentarioRepository
    {
        Task AdicionarAsync(List<Comentario> comentarios);
    }
}
