using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Interfaces.Specifications.Base;
using Lisbeth.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lisbeth.DataAccessLayer.Interfaces.Repositories.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(params object[] keyValues);
        Task<IReadOnlyList<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters);

        Task<IReadOnlyList<TEntity>> GetBySpecificationsAsync(PaginationFilter filter,
            ISpecifications<TEntity> specifications = null);

        Task<IReadOnlyList<TEntity>> GetBySpecificationsAsync(ISpecifications<TEntity> specifications = null);
        Task<long> CountAsync();
        Task<long> CountWhereAsync(ISpecifications<TEntity> specifications = null);
    }
}
