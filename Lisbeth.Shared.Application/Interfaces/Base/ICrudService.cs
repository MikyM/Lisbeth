using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lisbeth.Shared.Application.Interfaces.Base
{
    public interface ICrudService<TEntity, TDto> : IReadOnlyService<TEntity, TDto> where TEntity : Entity where TDto : IDto
    {
        Task<long> AddAsync(TDto dto, bool shouldSave = false);
        Task<long> AddAsync<TPostDto>(TPostDto dto, bool shouldSave = false) where TPostDto : IRequestDto;
        Task<bool> UpdateAsync<TPatchDto>(TPatchDto dto, bool shouldSave = false) where TPatchDto : IRequestDto;
        Task<bool> UpdateAsync(TDto dto, bool shouldSave = false);

        Task<bool> UpdateRangeAsync<TPatchDto>(IEnumerable<TPatchDto> dto, bool shouldSave = false)
            where TPatchDto : IRequestDto;

        Task<bool> UpdateRangeAsync(IEnumerable<TDto> dto, bool shouldSave = false);
        Task<long> AddOrUpdateAsync<TPutDto>(TPutDto dto, bool shouldSave = false) where TPutDto : IRequestDto;
        Task<long> AddOrUpdateAsync(TDto dto, bool shouldSave = false);

        Task<List<long>> AddOrUpdateRangeAsync<TPutDto>(IEnumerable<TPutDto> dtos, bool shouldSave = false)
            where TPutDto : IRequestDto;

        Task<List<long>> AddOrUpdateRangeAsync(IEnumerable<TDto> dtos, bool shouldSave = false);
        Task<bool> DeleteAsync<TDeleteDto>(TDeleteDto dto, bool shouldSave = false) where TDeleteDto : IRequestDto;
        Task<bool> DeleteAsync(TDto dto, bool shouldSave = false);
        Task<bool> DeleteAsync(long id, bool shouldSave = false);

        Task<bool> DeleteRangeAsync<TDeleteDto>(IEnumerable<TDeleteDto> dto, bool shouldSave = false)
            where TDeleteDto : IRequestDto;

        Task<bool> DeleteRangeAsync(IEnumerable<TDto> dto, bool shouldSave = false);
        Task<bool> DeleteRangeAsync(IEnumerable<long> ids, bool shouldSave = false);
    }
}
