using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.Interfaces.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(PaginationFilter filter);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, PaginationFilter filter);
        Task<long> CountAsync();
        Task<long> CountWhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
