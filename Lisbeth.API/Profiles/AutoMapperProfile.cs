using AutoMapper;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.DTOs.RequestDtos;
using Lisbeth.API.Domain.DTOs.ResponseDtos;
using Lisbeth.API.Domain.Entities;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
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

            CreateMap<EnvironmentDto, Environment>();
            CreateMap<EnvironmentReqDto, Environment>();

            //entity -> dto
            CreateMap<TestEntity, ResponseTestDto>();
            CreateMap<TestEntity, TestDto>();
            CreateMap<TestEntity, RequestTestDto>();

            CreateMap<Environment, EnvironmentDto>();
            CreateMap<Environment, EnvironmentResDto>();

            //audit
            CreateMap<AuditLog, AuditLogDto>();

            //filters
            CreateMap<PaginationFilterDto, PaginationFilter>();
        }
    }
}
