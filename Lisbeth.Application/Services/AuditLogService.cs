using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.Entities;
using MikyM.Common.Application.Interfaces;
using MikyM.Common.Application.Services;
using MikyM.Common.DataAccessLayer.UnitOfWork;

namespace Lisbeth.API.Application.Services
{
    public class AuditLogService : ReadOnlyService<AuditLog, AuditLogDto, LisbethDbContext>, IAuditLogService
    {
        public AuditLogService(IMapper mapper, IUnitOfWork<LisbethDbContext> uof) : base(mapper, uof)
        {
            
        }
    }
}
