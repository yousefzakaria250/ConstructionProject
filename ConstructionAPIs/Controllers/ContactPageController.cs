﻿using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageController : ControllerBase
    {
        private readonly IContactPageRepository contactPageRepository;

        public ContactPageController(IContactPageRepository contactPageRepository)
        {
            this.contactPageRepository = contactPageRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get(string Lang = "EN")
        {
            var res = await contactPageRepository.GetAll(Lang);
            return Ok(res);
        }
        [HttpPost("CreateConcat")]
        public async Task<IActionResult> CreateConcat([FromForm] ConcatDto dto)
        {
            if (dto.bg == null || dto.web == null)
                return BadRequest("Poster is required!");
            var result = await contactPageRepository.Insert(dto);
            return Ok(result);
        }

        [HttpPost("InsertIcon")]
        public async Task<IActionResult> CreateIcon([FromForm] IconDto dto)
        {
            if (dto.icon == null)
                return BadRequest("Icon is required!");
            var result = await contactPageRepository.InsertIcon(dto);
            return Ok(result);

        }
    }
}
