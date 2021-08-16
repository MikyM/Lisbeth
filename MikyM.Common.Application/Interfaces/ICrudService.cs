﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MikyM.Common.Domain.Entities;

namespace MikyM.Common.Application.Interfaces
{
    public interface ICrudService<TEntity, T> : IReadOnlyService<TEntity, T> where TEntity : AggregateRootEntity where T : class
    {
        Task<long> AddAsync(T addObject, bool shouldSave = false);
        Task<long> AddAsync<TPost>(TPost addObject, bool shouldSave = false) where TPost : class;
        Task<bool> UpdateAsync<TPatch>(TPatch patchObject, bool shouldSave = false) where TPatch : class;
        Task<bool> UpdateAsync(T patchObject, bool shouldSave = false);
        Task<bool> UpdateRangeAsync<TPatch>(IEnumerable<TPatch> patchObjects, bool shouldSave = false) where TPatch : class;
        Task<bool> UpdateRangeAsync(IEnumerable<T> patchObjects, bool shouldSave = false);
        Task<long> AddOrUpdateAsync<TPut>(TPut putObject, bool shouldSave = false) where TPut : class;
        Task<long> AddOrUpdateAsync(T putObject, bool shouldSave = false);
        Task<List<long>> AddOrUpdateRangeAsync<TPut>(IEnumerable<TPut> putObjects, bool shouldSave = false) where TPut : class;
        Task<List<long>> AddOrUpdateRangeAsync(IEnumerable<T> putObjects, bool shouldSave = false);
        Task<bool> DeleteAsync<TDelete>(TDelete deleteObject, bool shouldSave = false) where TDelete : class;
        Task<bool> DeleteAsync(T deleteObject, bool shouldSave = false);
        Task<bool> DeleteAsync(long id, bool shouldSave = false);
        Task<bool> DeleteRangeAsync<TDelete>(IEnumerable<TDelete> deleteObjects, bool shouldSave = false) where TDelete : class;
        Task<bool> DeleteRangeAsync(IEnumerable<T> deleteObjects, bool shouldSave = false);
        Task<bool> DeleteRangeAsync(IEnumerable<long> ids, bool shouldSave = false);
        Task<bool> DisableAsync<TDisable>(TDisable deleteObject, bool shouldSave = false) where TDisable : class;
        Task<bool> DisableAsync(T deleteObject, bool shouldSave = false);
        Task<bool> DisableAsync(long id, bool shouldSave = false);
        Task<bool> DisableRangeAsync<TDisable>(IEnumerable<TDisable> deleteObjects, bool shouldSave = false) where TDisable : class;
        Task<bool> DisableRangeAsync(IEnumerable<T> deleteObjects, bool shouldSave = false);
        Task<bool> DisableRangeAsync(IEnumerable<long> ids, bool shouldSave = false);
    }
}
