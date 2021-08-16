using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.Entities;
using Lisbeth.API.Helpers;
using Lisbeth.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikyM.Common.DataAccessLayer.Filters;
using MikyM.Common.DataAccessLayer.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace Lisbeth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditLogController : ControllerBase
    {
        private readonly ILogger<AuditLogController> _logger;
        private readonly IAuditLogService _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uri;

        public AuditLogController(ILogger<AuditLogController> logger, IAuditLogService service, IMapper mapper, IUriService uri)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _uri = uri;
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetAuditById(long id)
        {
            var res = await _service.GetAsync<AuditLogDto>(id);

            return res is null
                ? NotFound()
                : Ok(new Response<AuditLogDto>(res));
        }

        [HttpGet("by-table")]
        public async Task<IActionResult> GetAuditByTable([FromQuery] PaginationFilterDto filter, string name)
        {
            var spec = new Specifications<AuditLog>(x => x.TableName == name);
            var res = await _service.GetBySpecificationsAsync<AuditLogDto>(filter, spec);

            return res is null
                ? NotFound()
                : Ok(PaginationHelper.CreatePagedReponse(res.ToList(), _mapper.Map<PaginationFilter>(filter), await _service.CountWhereAsync(spec), _uri, Request.Path.Value));
        }
    }
}
