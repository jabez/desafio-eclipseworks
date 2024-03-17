using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Projetos
{
    public class ProjetoRepository : IProjetoRepository
    {
        public readonly TaskManagerContext _taskManagerContext;

        public ProjetoRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public async Task<Projeto> AdicionarAsync(Projeto projeto)
        {
            await _taskManagerContext.Projetos.AddAsync(projeto);
            await _taskManagerContext.SaveChangesAsync();

            return projeto;
        }

        public async Task<Projeto> ObterAsync(Guid id)
        {
            var item = await _taskManagerContext
                            .Projetos?
                            .Include(p => p.Tarefas)
                            .FirstOrDefaultAsync(p => p.Id == id)!;
            return item;
        }

        public async Task<IEnumerable<Projeto>> Where(Expression<Func<Projeto, bool>> predicate)
        {
            return await _taskManagerContext.Projetos.Where(predicate).ToListAsync();
        }

        public async Task<Projeto> AtualizarAsync(Projeto projeto)
        {
            _taskManagerContext.Entry(projeto).State = EntityState.Modified;
            var a = _taskManagerContext.ChangeTracker;
            await _taskManagerContext.SaveChangesAsync();

            return projeto;
        }
    }
}
