using Desafio.EclipseWorks.TaskManager.Domain.Entities;
using System.Linq.Expressions;

namespace Desafio.EclipseWorks.TaskManager.Domain.Interfaces.Repositories.Projetos
{
    public interface IProjetoRepository
    {
        Task<Projeto> AdicionarAsync(Projeto projeto);
        Task<Projeto> ObterAsync(Guid id);
        Task<IEnumerable<Projeto>> Where(Expression<Func<Projeto, bool>> predicate);
        Task<Projeto> AtualizarAsync(Projeto projeto);
    }
}
