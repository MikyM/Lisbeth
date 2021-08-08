using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Interfaces.Base;
using Lisbeth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Lisbeth.DataAccessLayer.Repositories.Base
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
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

        public async Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return await _context.Set<TEntity>().FromSqlRaw(query, parameters).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(PaginationFilter filter)
        {
            return await _context.Set<TEntity>()
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, PaginationFilter filter)
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<long> CountAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public async Task<long> CountWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().CountAsync();
        }
    }
}
