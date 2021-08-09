using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Shared.Application.Interfaces.Base;

namespace Lisbeth.Shared.Application.Services.Base
{
    public class CrudService<TEntity, TDto> : ReadOnlyService<TEntity, TDto>, ICrudService<TEntity, TDto> where TEntity : Entity where TDto : IDto
    {
        public CrudService(IMapper mapper, IUnitOfWork uof) : base(mapper, uof)
        {
        }

        public async Task<long> Add(TDto dto, bool shouldSave = false)
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

        public async Task<long> Add<TPostDto>(TPostDto dto, bool shouldSave = false) where TPostDto : IRequestDto
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

        public async Task<bool> Update<TPatchDto>(TPatchDto dto, bool shouldSave = false) where TPatchDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Update(_mapper.Map<TEntity>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }
        

        public async Task<bool> Update(TDto dto, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Update(_mapper.Map<TEntity>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<bool> UpdateRange(IEnumerable<TDto> dto, bool shouldSave = false)
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<bool> UpdateRange<TPatchDto>(IEnumerable<TPatchDto> dto, bool shouldSave = false) where TPatchDto : IRequestDto
        {
            _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dto));
            if (shouldSave)
                await CommitAsync();
            return true;
            //to do
        }

        public async Task<long> AddOrUpdate(TDto dto, bool shouldSave = false)
        {
            var entity = _mapper.Map<TEntity>(dto);
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdate(entity);
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

        public async Task<long> AddOrUpdate<TPutDto>(TPutDto dto, bool shouldSave = false) where TPutDto : IRequestDto
        {
            var entity = _mapper.Map<TEntity>(dto);
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdate(entity);

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

        public async Task<List<long>> AddOrUpdateRange(IEnumerable<TDto> dtos, bool shouldSave = false)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtos).ToList();
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdateRange(entities);

                if (shouldSave)
                    await CommitAsync();
                else
                    return new List<long>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return entities.Select(x => x.Id).ToList();
        }

        public async Task<List<long>> AddOrUpdateRange<TPutDto>(IEnumerable<TPutDto> dtos, bool shouldSave = false) where TPutDto : IRequestDto
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtos).ToList();
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().AddOrUpdateRange(entities);

                if (shouldSave)
                    await CommitAsync();
                else
                    return new List<long>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return entities.Select(x => x.Id).ToList();
        }

        public async Task<bool> Delete(TDto dto, bool shouldSave = false)
        {
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(_mapper.Map<TEntity>(dto));

                if (shouldSave)
                    await CommitAsync();
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete<TDeleteDto>(TDeleteDto dto, bool shouldSave = false) where TDeleteDto : IRequestDto
        {
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(_mapper.Map<TEntity>(dto));

                if (shouldSave)
                    await CommitAsync();
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(long id, bool shouldSave = false)
        {
            try
            {
                var entity = (TEntity) Activator.CreateInstance(typeof(TEntity), id);
                //_unitOfWork.Context.Attach(entity);
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().Delete(entity);

                if (shouldSave)
                    await CommitAsync();
                else
                    return false;
            }
            catch (Exception ex)
            {
                return true;
            }

            return true;
        }

        public async Task<bool> DeleteRange(IEnumerable<long> ids, bool shouldSave = false)
        {
            try
            {
                List<TEntity> entities = new();
                foreach (long id in ids)
                {
                    var entity = (TEntity) Activator.CreateInstance(typeof(TEntity));
                    entities.Add(entity);
                }
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().DeleteRange(entities);

                if (shouldSave)
                    await CommitAsync();
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteRange<TDeleteDto>(IEnumerable<TDeleteDto> dtos, bool shouldSave = false) where TDeleteDto : IRequestDto
        {
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().DeleteRange(_mapper.Map<IEnumerable<TEntity>>(dtos));

                if (shouldSave)
                    await CommitAsync();
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteRange(IEnumerable<TDto> dtos, bool shouldSave = false)
        {
            try
            {
                _unitOfWork.GetRepository<TEntity, Repository<TEntity>>().DeleteRange(_mapper.Map<IEnumerable<TEntity>>(dtos));

                if (shouldSave)
                    await CommitAsync();
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
