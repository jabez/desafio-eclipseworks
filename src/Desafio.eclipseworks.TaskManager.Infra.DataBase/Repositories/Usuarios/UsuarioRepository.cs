using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly TaskManagerContext _taskManagerContext;

        public UsuarioRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            await _taskManagerContext.Usuarios.AddAsync(usuario);
            await _taskManagerContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> ObterAsync(Guid id)
        {
            var item = await _taskManagerContext.Usuarios?
                                                .Include(u => u.Projetos)
                                                .Include(u => u.Comentarios)
                                                .FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<List<Usuario>> ObterTodosPaginadoAsync(int pageSize, int pageNumber)
        {
            return await _taskManagerContext.Usuarios?
                         .AsNoTracking()
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();
        }

        public async Task<Usuario> AtualizarAsync(Usuario usuario)
        {
            _taskManagerContext.Entry(usuario).State = EntityState.Modified;
            await _taskManagerContext.SaveChangesAsync();

            return usuario;
        }
    }
}
