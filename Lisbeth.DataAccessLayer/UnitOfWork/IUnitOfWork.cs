using System;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Microsoft.EntityFrameworkCore.DbContext Context { get; }

        public TRepository GetRepository<TEntity, TRepository>()
            where TEntity : Entity
            where TRepository : ReadOnlyRepository<TEntity>;

        Task<int> CommitAsync();
        Task RollbackAsync();
        Task UseTransaction();
    }
}
