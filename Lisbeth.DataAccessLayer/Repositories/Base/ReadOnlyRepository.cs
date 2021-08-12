using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Interfaces.Repositories.Base;
using Lisbeth.DataAccessLayer.Interfaces.Specifications.Base;
using Lisbeth.DataAccessLayer.Specifications.Base;
using Lisbeth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lisbeth.DataAccessLayer.Repositories.Base
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : RepositoryEntity
    {
        protected Microsoft.EntityFrameworkCore.DbContext _context;

        public ReadOnlyRepository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        public async Task<IReadOnlyList<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return await _context.Set<TEntity>().FromSqlRaw(query, parameters).AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetBySpecificationsAsync(
            ISpecifications<TEntity> baseSpecifications = null)
        {
            return await SpecificationEvaluator<TEntity>
                .GetQuery(_context.Set<TEntity>().AsQueryable(), baseSpecifications)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetBySpecificationsAsync(PaginationFilter filter,
            ISpecifications<TEntity> baseSpecifications = null)
        {
            return await SpecificationEvaluator<TEntity>
                .GetQuery(_context.Set<TEntity>().AsQueryable(), baseSpecifications)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<long> CountAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().LongCountAsync();
        }

        public async Task<long> CountWhereAsync(ISpecifications<TEntity> specifications = null)
        {
            return await SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>().AsQueryable(), specifications)
                .AsNoTracking()
                .LongCountAsync();
        }
    }
}
