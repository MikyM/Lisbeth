using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Interfaces.Specifications.Base;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities.Base;

namespace Lisbeth.Shared.Application.Interfaces.Base
{
    public interface IReadOnlyService<TEntity, TDto> : IServiceBase where TEntity : Entity where TDto : IDto
    {
        Task<TDto> GetAsync(long id);
        Task<TGetDto> GetAsync<TGetDto>(long id) where TGetDto : IResponseDto;
        Task<IReadOnlyList<TDto>> GetWithRawSqlAsync(string query, params object[] parameters);
        Task<IReadOnlyList<TGetDto>> GetWithRawSqlAsync<TGetDto>(string query, params object[] parameters) where TGetDto : IResponseDto;
        Task<IReadOnlyList<TDto>> GetBySpecificationsAsync(ISpecifications<TEntity> specifications = null);
        Task<IReadOnlyList<TGetDto>> GetBySpecificationsAsync<TGetDto>(ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto;
        Task<IReadOnlyList<TDto>> GetBySpecificationsAsync(PaginationFilterDto filter, ISpecifications<TEntity> specifications = null);
        Task<IReadOnlyList<TGetDto>> GetBySpecificationsAsync<TGetDto>(PaginationFilterDto filter, ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto;
        Task<long> CountAsync();
        Task<long> CountWhereAsync(ISpecifications<TEntity> specifications = null);
        Task<long> CountWhereAsync<TGetDto>(ISpecifications<TEntity> specifications = null) where TGetDto : IResponseDto;
    }
}
