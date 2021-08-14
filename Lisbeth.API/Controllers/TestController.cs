using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.Application.Services;
using Lisbeth.API.Domain.DTOs;
using Lisbeth.API.Domain.Entities;
using Lisbeth.API.Helpers;
using Lisbeth.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MikyM.Common.DataAccessLayer.Filters;
using MikyM.Common.DataAccessLayer.Specifications;

namespace Lisbeth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestEntityService _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uri;

        public TestController(ILogger<TestController> logger, ITestEntityService service, IMapper mapper, IUriService uri)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _uri = uri;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var res = await _service.GetAsync(id);

            return res is null
                ? NotFound()
                : Ok(new Response<TestDto>(res));
        }

        [HttpGet("by-name-paginated")]
        public async Task<IActionResult> GetByNamePaginated([FromQuery] PaginationFilterDto filter, string name)
        {
            var spec = new Specifications<TestEntity>(x => x.Name == name);
            var res = await _service.GetBySpecificationsAsync(filter, spec);
            if (res is null)
                return NotFound();
            var ok = PaginationHelper.CreatePagedReponse(res.ToList(), _mapper.Map<PaginationFilter>(filter), await _service.CountWhereAsync(spec), _uri, Request.Path.Value);
            return Ok(ok);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestDto dto)
        {
            var res = await _service.AddAsync(dto, true);

            return res is -1
                ? BadRequest()
                : Ok(new Response<long>(res));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TestDto dto)
        {
            var res = await _service.AddOrUpdateAsync(dto, true);

            return res is -1
                ? BadRequest()
                : res is 0
                    ? Ok(new Response<bool>(true))
                    : Ok(new Response<long>(res));
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] TestDto dto)
        {
            var res = await _service.UpdateAsync(dto, true);

            return res is false
                ? BadRequest()
                : Ok(new Response<bool>(res));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _service.DeleteAsync(id, true);

            return res is false
                ? BadRequest()
                : Ok(new Response<bool>(res));
        }
    }
}
