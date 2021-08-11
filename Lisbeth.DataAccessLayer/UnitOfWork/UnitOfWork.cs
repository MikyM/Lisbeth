using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Lisbeth.DataAccessLayer.Helpers;

namespace Lisbeth.DataAccessLayer.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public Microsoft.EntityFrameworkCore.DbContext Context { get; }
        private Dictionary<string, object> _repositories;
        private IDbContextTransaction _transaction;

        public UnitOfWork(Microsoft.EntityFrameworkCore.DbContext context)
        {
            Context = context;
        }

        public async Task UseTransaction()
        {
            _transaction ??= await Context.Database.BeginTransactionAsync();
        }

        public TRepository GetRepository<TEntity, TRepository>() where TEntity : Entity
            where TRepository : ReadOnlyRepository<TEntity>
        {
            return (TRepository) GetOrAddRepository(typeof(TRepository));
        }

        private object GetOrAddRepository(Type type)
        {
            _repositories ??= new();
            string name = type.FullName;
            if (_repositories.TryGetValue(name, out var repository)) return repository;

            var concrete =
                UoFCache.CachedTypes.FirstOrDefault(x => type.IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);
            if (concrete is not null)
            {
                string concreteName = concrete.FullName;
                if (_repositories.TryGetValue(concreteName, out var concreteRepo)) return concreteRepo;
                var concreteArgs = new object[] {Context};
                if (_repositories.TryAdd(concreteName, Activator.CreateInstance(concrete, concreteArgs)))
                    return _repositories[concreteName];
                throw new ArgumentException(
                    $"Concrete repository of type {concreteName} couldn't be added to and/or retrieved from cache.");
            }

            var args = new object[] {Context};
            if (_repositories.TryAdd(name, Activator.CreateInstance(type, args))) return _repositories[name];
            throw new ArgumentException(
                $"Concrete repository of type {name} couldn't be added to and/or retrieved from cache.");
        }

        public async Task RollbackAsync()
        {
            if (_transaction is not null) await _transaction.RollbackAsync();
        }

        public async Task<int> CommitAsync()
        {
            int result = await Context.SaveChangesAsync();
            if (_transaction is not null) await _transaction.CommitAsync();
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
                // get rid of managed resources
            }
            // get rid of unmanaged resources
        }
    }
}
