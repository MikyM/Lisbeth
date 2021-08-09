using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Interfaces.Specifications.Base;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Shared.Application.Interfaces.Base;

namespace Lisbeth.Shared.Application.Services.Base
{
    public class ReadOnlyService<TEntity, TDto> : ServiceBase, IReadOnlyService<TEntity, TDto> where TEntity : Entity where TDto : IDto
    {

        public ReadOnlyService(IMapper mapper, IUnitOfWork uof) : base(mapper, uof)
        {
        }

        public async Task<TDto> GetAsync(long id)
        {
            return _mapper.Map<TDto>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAsync(id));
        }

        public async Task<TGetDto> GetAsync<TGetDto>(long id) where TGetDto : IResponseDto
        {
            return _mapper.Map<TGetDto>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAsync(id));
        }

        public async Task<IReadOnlyList<TDto>> GetBySpecificationsAsync(ISpecifications<TEntity> specifications = null)
        {
            return _mapper.Map<IReadOnlyList<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetBySpecificationsAsync(specifications));
        }

        public async Task<IReadOnlyList<TGetDto>> GetBySpecificationsAsync<TGetDto>(ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto
        {
            return _mapper.Map<IReadOnlyList<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetBySpecificationsAsync(specifications));
        }

        public async Task<IReadOnlyList<TDto>> GetBySpecificationsAsync(PaginationFilterDto filter, ISpecifications<TEntity> specifications = null)
        {
            return _mapper.Map<IReadOnlyList<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetBySpecificationsAsync(_mapper.Map<PaginationFilter>(filter), specifications));
        }

        public async Task<IReadOnlyList<TGetDto>> GetBySpecificationsAsync<TGetDto>(PaginationFilterDto filter, ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto
        {
            return _mapper.Map<IReadOnlyList<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetBySpecificationsAsync(_mapper.Map<PaginationFilter>(filter), specifications));
        }

        public async Task<IReadOnlyList<TDto>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return _mapper.Map<IReadOnlyList<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWithRawSqlAsync(query, parameters));
        }

        public async Task<IReadOnlyList<TGetDto>> GetWithRawSqlAsync<TGetDto>(string query, params object[] parameters) where TGetDto : IResponseDto
        {
            return _mapper.Map<IReadOnlyList<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWithRawSqlAsync(query, parameters));
        }

        public async Task<long> CountAsync()
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().CountAsync();
        }

        public async Task<long> CountWhereAsync(ISpecifications<TEntity> specifications = null)
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                .CountWhereAsync(specifications);
        }

        public async Task<long> CountWhereAsync<TGetDto>(ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                .CountWhereAsync(specifications);
        }
    }
}
