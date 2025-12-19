using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iticket.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[]? includes);
        Task<List<TEntity>> GetAllSortedAsync<TOrderBy>(Expression<Func<TEntity, TOrderBy>>? orderBy = null, bool isASC = true, Expression<Func<TEntity, bool>>? predicate = null, params string[]? includes);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
