using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;
using Lisbeth.Shared.Application.Interfaces.Base;

namespace Lisbeth.Shared.Application.Services.Base
{
    public class ReadOnlyService<TEntity, TDto> : ServiceBase, IReadOnlyService<TEntity, TDto> where TEntity : Entity where TDto : Dto
    {

        public ReadOnlyService(IMapper mapper, IUnitOfWork uof) : base(mapper, uof)
        {
        }

        public async Task<TDto> GetAsync(long id)
        {
            return _mapper.Map<TDto>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAsync(id));
        }

        public async Task<TGetDto> GetAsync<TGetDto>(long id) where TGetDto : Dto
        {
            return _mapper.Map<TGetDto>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAsync(id));
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TDto>>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAllAsync());
        }

        public async Task<IEnumerable<TGetDto>> GetAllAsync<TGetDto>() where TGetDto : Dto
        {
            return _mapper.Map<IEnumerable<TGetDto>>(await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().GetAllAsync());
        }

        public async Task<IEnumerable<TDto>> GetAllAsync(PaginationFilterDto filter)
        {
            return _mapper.Map<IEnumerable<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetAllAsync(_mapper.Map<PaginationFilter>(filter)));
        }

        public async Task<IEnumerable<TGetDto>> GetAllAsync<TGetDto>(PaginationFilterDto filter) where TGetDto : Dto
        {
            return _mapper.Map<IEnumerable<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetAllAsync(_mapper.Map<PaginationFilter>(filter)));
        }

        public async Task<IEnumerable<TDto>> GetWhereAsync(Expression<Func<TDto, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate)));
        }

        public async Task<IEnumerable<TGetDto>> GetWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate) where TGetDto : Dto
        {
            return _mapper.Map<IEnumerable<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate)));
        }

        public async Task<IEnumerable<TDto>> GetWhereAsync(Expression<Func<TDto, bool>> predicate, PaginationFilterDto filter)
        {
            return _mapper.Map<IEnumerable<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate), _mapper.Map<PaginationFilter>(filter)));
        }

        public async Task<IEnumerable<TGetDto>> GetWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate, PaginationFilterDto filter) where TGetDto : Dto
        {
            return _mapper.Map<IEnumerable<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate), _mapper.Map<PaginationFilter>(filter)));
        }

        public async Task<IEnumerable<TDto>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return _mapper.Map<IEnumerable<TDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWithRawSqlAsync(query, parameters));
        }

        public async Task<IEnumerable<TGetDto>> GetWithRawSqlAsync<TGetDto>(string query, params object[] parameters) where TGetDto : Dto
        {
            return _mapper.Map<IEnumerable<TGetDto>>(
                await _unitOfWork
                    .GetRepository<TEntity, ReadOnlyRepository<TEntity>>()
                    .GetWithRawSqlAsync(query, parameters));
        }

        public async Task<long> CountAsync()
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().CountAsync();
        }

        public async Task<long> CountWhereAsync(Expression<Func<TDto, bool>> predicate)
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().CountWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate));
        }

        public async Task<long> CountWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate) where TGetDto : Dto
        {
            return await _unitOfWork.GetRepository<TEntity, ReadOnlyRepository<TEntity>>().CountWhereAsync(_mapper.Map<Expression<Func<TEntity, bool>>>(predicate));
        }
    }
}
