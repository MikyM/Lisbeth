using System.Linq;
using System.Threading.Tasks;
using Lisbeth.API.Helpers;
using Lisbeth.API.Models;
using Lisbeth.DataAccessLayer.Filters;
using Lisbeth.Domain.DTOs;
using Lisbeth.Domain.Entities;
using Lisbeth.Shared.Application.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lisbeth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ICrudService<TestEntity,TestDto> _service;

        public TestController(ILogger<TestController> logger, ICrudService<TestEntity, TestDto> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var res = await _service.GetAsync(id);

            return res is null
                ? NotFound()
                : Ok(new Response<TestDto>(res));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestDto dto)
        {
            var res = await _service.Add(dto, true);

            return res is -1
                ? BadRequest()
                : Ok(new Response<long>(res));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TestDto dto)
        {
            var res = await _service.AddOrUpdate(dto, true);

            return res is -1
                ? BadRequest()
                : res is 0
                    ? Ok(new Response<bool>(true))
                    : Ok(new Response<long>(res));
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] TestDto dto)
        {
            var res = await _service.Update(dto, true);

            return res is false
                ? BadRequest()
                : Ok(new Response<bool>(res));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await _service.Delete(id, true);

            return res is false
                ? BadRequest()
                : Ok(new Response<bool>(res));
        }
    }
}
