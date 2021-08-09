using System.Collections.Generic;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Interfaces.Repositories.Base;
using Lisbeth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Lisbeth.DataAccessLayer.Repositories.Base
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        public Repository(Microsoft.EntityFrameworkCore.DbContext context) : base(context)
        {
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void AddOrUpdate(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void AddOrUpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }


        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Attach(entity).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
