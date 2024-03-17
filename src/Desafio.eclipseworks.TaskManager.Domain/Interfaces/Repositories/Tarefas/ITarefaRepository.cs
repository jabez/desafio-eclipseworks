using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Tarefas
{
    public interface ITarefaRepository
    {
        Task<Tarefa> AdicionarAsync(Tarefa tarefa);
        Task<Tarefa> ObterAsync(int id);
        Task<IEnumerable<Tarefa>> Where(Expression<Func<Tarefa, bool>> predicate);
        Task<Tarefa> AtualizarAsync(Tarefa tarefa);
        Task<Tarefa> ObterTarefaAsync(int id);
    }
}
