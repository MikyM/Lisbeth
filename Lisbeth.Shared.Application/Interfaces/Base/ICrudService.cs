﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Shared.Application.Interfaces.Base
{
    public interface ICrudService<TEntity, TDto> : IReadOnlyService<TEntity, TDto> where TEntity : Entity where TDto : IDto
    {
        Task<long> Add(TDto dto, bool shouldSave = false);
        Task<long> Add<TPostDto>(TPostDto dto, bool shouldSave = false) where TPostDto : IRequestDto;
        Task<bool> Update<TPatchDto>(TPatchDto dto, bool shouldSave = false) where TPatchDto : IRequestDto;
        Task<bool> Update(TDto dto, bool shouldSave = false);
        Task<bool> UpdateRange<TPatchDto>(IEnumerable<TPatchDto> dto, bool shouldSave = false) where TPatchDto : IRequestDto;
        Task<bool> UpdateRange(IEnumerable<TDto> dto, bool shouldSave = false);
        Task<long> AddOrUpdate<TPutDto>(TPutDto dto, bool shouldSave = false) where TPutDto : IRequestDto;
        Task<long> AddOrUpdate(TDto dto, bool shouldSave = false);
        Task<List<long>> AddOrUpdateRange<TPutDto>(IEnumerable<TPutDto> dtos, bool shouldSave = false) where TPutDto : IRequestDto;
        Task<List<long>> AddOrUpdateRange(IEnumerable<TDto> dtos, bool shouldSave = false);
        Task<bool> Delete<TDeleteDto>(TDeleteDto dto, bool shouldSave = false) where TDeleteDto : IRequestDto;
        Task<bool> Delete(TDto dto, bool shouldSave = false);
        Task<bool> Delete(long id, bool shouldSave = false);
        Task<bool> DeleteRange<TDeleteDto>(IEnumerable<TDeleteDto> dto, bool shouldSave = false) where TDeleteDto : IRequestDto;
        Task<bool> DeleteRange(IEnumerable<TDto> dto, bool shouldSave = false);
        Task<bool> DeleteRange(IEnumerable<long> ids, bool shouldSave = false);
    }
}
