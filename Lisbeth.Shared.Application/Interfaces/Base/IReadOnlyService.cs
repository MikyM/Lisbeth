using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Shared.Application.Interfaces.Base
{
    public interface IReadOnlyService<TEntity, TDto> : IServiceBase where TEntity : Entity where TDto : Dto
    {
        Task<TDto> GetAsync(long id);
        Task<TGetDto> GetAsync<TGetDto>(long id) where TGetDto : Dto;
        Task<IEnumerable<TDto>> GetWithRawSqlAsync(string query, params object[] parameters);
        Task<IEnumerable<TGetDto>> GetWithRawSqlAsync<TGetDto>(string query, params object[] parameters) where TGetDto : Dto;
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<IEnumerable<TGetDto>> GetAllAsync<TGetDto>() where TGetDto : Dto;
        Task<IEnumerable<TDto>> GetAllAsync(PaginationFilterDto filter);
        Task<IEnumerable<TGetDto>> GetAllAsync<TGetDto>(PaginationFilterDto filter) where TGetDto : Dto;
        Task<IEnumerable<TDto>> GetWhereAsync(Expression<Func<TDto, bool>> predicate);
        Task<IEnumerable<TGetDto>> GetWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate) where TGetDto : Dto;
        Task<IEnumerable<TDto>> GetWhereAsync(Expression<Func<TDto, bool>> predicate, PaginationFilterDto filter);
        Task<IEnumerable<TGetDto>> GetWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate, PaginationFilterDto filter) where TGetDto : Dto;
        Task<long> CountAsync();
        Task<long> CountWhereAsync(Expression<Func<TDto, bool>> predicate);
        Task<long> CountWhereAsync<TGetDto>(Expression<Func<TGetDto, bool>> predicate) where TGetDto : Dto;
    }
}
