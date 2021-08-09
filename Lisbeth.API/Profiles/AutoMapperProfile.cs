using AutoMapper;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.Domain.DTOs;
using Lisbeth.Domain.DTOs.Base;
using Lisbeth.Domain.Entities;

namespace Lisbeth.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //dto -> entity
            CreateMap<TestDto, TestEntity>();
            CreateMap<RequestTestDto, TestEntity>();
            CreateMap<ResponseTestDto, TestEntity>();

            //entity -> dto
            CreateMap<TestEntity, ResponseTestDto>();
            CreateMap<TestEntity, TestDto>();
            CreateMap<TestEntity, RequestTestDto>();

            //audit
            CreateMap<AuditLog, AuditLogDto>();

            //filters
            CreateMap<PaginationFilterDto, PaginationFilter>();
        }
    }
}
