using Desafio.EclipseWorks.TaskManager.Domain.Entities;

namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarAsync(Usuario usuario);
        Task<Usuario> ObterAsync(Guid id);
        Task<Usuario> AtualizarAsync(Usuario usuario);
        Task<List<Usuario>> ObterTodosPaginadoAsync(int pageSize, int pageNumber);
    }
}
