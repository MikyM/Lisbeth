using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.Helpers;
using Lisbeth.API.Models;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.DataAccessLayer.Specifications.Base;
using Lisbeth.Domain.DTOs;
using Lisbeth.Domain.Entities;
using Lisbeth.Shared.Application.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lisbeth.API.Controllers
{
    public class AuditLogController : ControllerBase
    {
        private readonly ILogger<AuditLogController> _logger;
        private readonly IReadOnlyService<AuditLog, AuditLogDto> _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uri;

        public AuditLogController(ILogger<AuditLogController> logger, IReadOnlyService<AuditLog, AuditLogDto> service, IMapper mapper, IUriService uri)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _uri = uri;
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetAuditById(long id)
        {
            var res = await _service.GetAsync(id);

            return res is null
                ? NotFound()
                : Ok(new Response<AuditLogDto>(res));
        }

        [HttpGet("by-table")]
        public async Task<IActionResult> GetAuditByTable([FromQuery] PaginationFilterDto filter, string name)
        {
            var spec = new Specifications<AuditLog>(x => x.TableName == name);
            var res = await _service.GetBySpecificationsAsync(filter, spec);

            return res is null
                ? NotFound()
                : Ok(PaginationHelper.CreatePagedReponse(res.ToList(), _mapper.Map<PaginationFilter>(filter), await _service.CountWhereAsync(spec), _uri, Request.Path.Value));
        }
    }
}
