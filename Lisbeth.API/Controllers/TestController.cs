﻿using System.Linq;
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
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Ocsp;

namespace Lisbeth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ICrudService<TestEntity,TestDto> _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uri;

        public TestController(ILogger<TestController> logger, ICrudService<TestEntity, TestDto> service, IMapper mapper, IUriService uri)
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
