using AutoMapper;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.Domain.DTOs;
using Lisbeth.Domain.Entities;

namespace Lisbeth.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TestDto, TestEntity>();
            CreateMap<TestEntity, TestDto>();
            CreateMap<PaginationFilterDto, PaginationFilter>();
        }
    }
}
