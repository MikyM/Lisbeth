using System;
using AutoMapper;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.DTOs.RequestDtos;
using Lisbeth.API.Domain.DTOs.ResponseDtos;
using Lisbeth.API.Domain.Entities;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using Lisbeth.API.Domain.Entities.EnvironmentSpecificEntities;
using MikyM.Common.DataAccessLayer.Filters;
using Environment = Lisbeth.API.Domain.Entities.AggregateRootEntities.Environment;

namespace Lisbeth.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //dto -> entity
            CreateMap<EnvironmentReqDto, Environment>();
            CreateMap<ProjectReqDto, Project>();
            CreateMap<QueueReqDto, Queue>();
            CreateMap<TicketReqDto, Ticket>();
            CreateMap<BugReqDto, Bug>();
            CreateMap<TrackerReqDto, Tracker>();
            CreateMap<StatusReqDto, Status>();
            CreateMap<SpentTimeTypeReqDto, SpentTimeType>();

            //entity -> dto
            CreateMap<Environment, EnvironmentResDto>();
            CreateMap<Project, ProjectResDto>();
            CreateMap<Queue, QueueResDto>();
            CreateMap<Ticket, TicketResDto>();
            CreateMap<Bug, BugResDto>();
            CreateMap<Tracker, TrackerResDto>();
            CreateMap<Status, StatusResDto>();
            CreateMap<SpentTimeType, SpentTimeTypeResDto>();

            //audit
            CreateMap<AuditLog, AuditLogDto>();

            //filters
            CreateMap<PaginationFilterDto, PaginationFilter>();

            //additional
            CreateMap<Uri, Attachment>().ForMember(dest => dest.Uri, opt => opt.MapFrom(src => src));
        }
    }
}
