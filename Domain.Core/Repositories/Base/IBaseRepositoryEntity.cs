using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Repositories.Base
{
    public interface IBaseRepositoryEntity<T>
    {
        Task Add(T entity, bool save = true);
        Task Add(List<T> entities, bool save = true);
        Task Alt(T entity, bool save = true);
        Task Alt(List<T> entities, bool save = true);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
    }
}
