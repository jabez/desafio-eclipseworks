using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Infra.DataBase.Repositories.Tarefas
{
    public class TarefaRepository : ITarefaRepository
    {
        public readonly TaskManagerContext _taskManagerContext;

        public TarefaRepository(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        public async Task<Tarefa> AdicionarAsync(Tarefa tarefa)
        {
            await _taskManagerContext.Tarefas.AddAsync(tarefa);
            await _taskManagerContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> AtualizarAsync(Tarefa tarefa)
        {
            _taskManagerContext.Entry(tarefa).State = EntityState.Modified;
            await _taskManagerContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<Tarefa> ObterAsync(int id)
        {
            var item = await _taskManagerContext
                                .Tarefas?
                                .FirstOrDefaultAsync(p => p.Id == id)!;
            return item;
        }

        public async Task<Tarefa> ObterTarefaAsync(int id)
        {
            var item = await _taskManagerContext
                                .Tarefas?.AsNoTracking()
                                .FirstOrDefaultAsync(p => p.Id == id)!;
            return item;
        }

        public async Task<IEnumerable<Tarefa>> Where(Expression<Func<Tarefa, bool>> predicate)
        {
            return await _taskManagerContext.Tarefas.Where(predicate).ToListAsync();
        }
    }
}
