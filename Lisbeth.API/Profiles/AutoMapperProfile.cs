using AutoMapper;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.Entities;
using MikyM.Common.DataAccessLayer.Filters;

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
