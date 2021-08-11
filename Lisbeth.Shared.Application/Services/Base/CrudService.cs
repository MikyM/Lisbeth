using AutoMapper;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Shared.Application.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lisbeth.Shared.Application.Services.Base
{
    public class CrudService<TEntity, TDto> : ReadOnlyService<TEntity, TDto>, ICrudService<TEntity, TDto> where TEntity : Entity where TDto : IDto
    {
        public CrudService(IMapper mapper, IUnitOfWork uof) : base(mapper, uof)
        {
        }

        public async Task<long> AddAsync(TDto dto, bool shouldSave = false)
        {
            var entity = _mapper.Map<TEntity>(dto);
            try
            {
                await _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddAsync(entity);

                if (shouldSave)
                    await CommitAsync();
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }

            return entity.Id;
        }

        public async Task<long> AddAsync<TPostDto>(TPostDto dto, bool shouldSave = false) where TPostDto : IRequestDto
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddAsync(entity);
            if (shouldSave)
                await CommitAsync();
            else
                return 0;
            return entity.Id;
        }

        public async Task<bool> UpdateAsync<TPatchDto>(TPatchDto dto, bool shouldSave = false) where TPatchDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Update(_mapper.Map<TEntity>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }
        

        public async Task<bool> UpdateAsync(TDto dto, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Update(_mapper.Map<TEntity>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<bool> UpdateRangeAsync(IEnumerable<TDto> dto, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<bool> UpdateRangeAsync<TPatchDto>(IEnumerable<TPatchDto> dto, bool shouldSave = false) where TPatchDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<long> AddOrUpdateAsync(TDto dto, bool shouldSave = false)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdate(entity);
            if (shouldSave)
                await CommitAsync();
            else
                return 0;
            return entity.Id;
        }

        public async Task<long> AddOrUpdateAsync<TPutDto>(TPutDto dto, bool shouldSave = false) where TPutDto : IRequestDto
        {
            var entity = _mapper.Map<TEntity>(dto);
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdate(entity);
            if (shouldSave)
                await CommitAsync();
            else
                return 0;
            return entity.Id;
        }

        public async Task<List<long>> AddOrUpdateRangeAsync(IEnumerable<TDto> dtos, bool shouldSave = false)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtos).ToList();
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdateRange(entities);
            if (shouldSave)
                await CommitAsync();
            else
                return new List<long>();
            return entities.Select(x => x.Id).ToList();
        }

        public async Task<List<long>> AddOrUpdateRangeAsync<TPutDto>(IEnumerable<TPutDto> dtos, bool shouldSave = false) where TPutDto : IRequestDto
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtos).ToList();
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdateRange(entities);

            if (shouldSave)
                await CommitAsync();
            else
                return new List<long>();
            return entities.Select(x => x.Id).ToList();
        }

        public async Task<bool> DeleteAsync(TDto dto, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(_mapper.Map<TEntity>(dto));

            if (shouldSave)
                await CommitAsync();
            else
                return true;
            return true;
            //to do
        }

        public async Task<bool> DeleteAsync<TDeleteDto>(TDeleteDto dto, bool shouldSave = false) where TDeleteDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(_mapper.Map<TEntity>(dto));

            if (shouldSave)
                await CommitAsync();
            else
                return true;
            return true;
            //to do
        }

        public async Task<bool> DeleteAsync(long id, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(id);
            if (shouldSave)
                await CommitAsync();
            else
                return false;
            return true;
            //to do
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<long> ids, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().DeleteRange(ids);

            if (shouldSave)
                await CommitAsync();
            else
                return true;
            return true;
            //to do
        }

        public async Task<bool> DeleteRangeAsync<TDeleteDto>(IEnumerable<TDeleteDto> dtos, bool shouldSave = false) where TDeleteDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>()
                .DeleteRange(_mapper.Map<IEnumerable<TEntity>>(dtos));

            if (shouldSave)
                await CommitAsync();
            else
                return true;
            return true;
            //to do
        }

        public async Task<bool> DeleteRangeAsync(IEnumerable<TDto> dtos, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>()
                .DeleteRange(_mapper.Map<IEnumerable<TEntity>>(dtos));

            if (shouldSave)
                await CommitAsync();
            else
                return true;
            return true;
            //to do
        }
    }
}
