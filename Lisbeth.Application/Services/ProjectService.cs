﻿using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.Domain.Entities.AggregateRootEntities;
using MikyM.Common.Application.Services;
using MikyM.Common.DataAccessLayer.UnitOfWork;

namespace Lisbeth.API.Application.Services
{
    public class ProjectService : CrudService<Project, LisbethDbContext>, IProjectService
    {
        public ProjectService(IMapper mapper, IUnitOfWork<LisbethDbContext> ctx) : base(mapper, ctx)
        {

        }
    }
}