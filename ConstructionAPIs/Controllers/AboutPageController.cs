using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutPageController : ControllerBase
    {
        private readonly IAboutPageRepository aboutPageRepository;
        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png",".jpeg" };
        public AboutPageController(IAboutPageRepository aboutPageRepository)
        {
            this.aboutPageRepository = aboutPageRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Details(string Lang = "en")
        {   
            var result = await aboutPageRepository.GetAll(Lang);
            return Ok(result);
        }
        [HttpPost("CreateAbout")]

        public async Task<IActionResult> AddAbout( [FromForm] AboutDto dto)
        {
            if (dto.bg == null)
                return BadRequest("Poster is required!");

            //if (!_allowedExtenstions.Contains(Path.GetExtension(dto.bg.FileName).ToLower()))
            //    return BadRequest("Only .png and .jpg images are allowed!");

            var result = aboutPageRepository.Insert(dto);
            return Ok(result);
        }

        [HttpPost("CreateSection")]
        public async Task<IActionResult> AddSection([FromForm] SectionDto dto)
        {
            if (dto.image == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.image.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            var result = aboutPageRepository.InsertSection(dto);
            return Ok(result);
        }

        [HttpPut("UpdateAboutPage")]
        public async Task<IActionResult> UpdatePage(int id , [FromForm]AboutDto aboutDto)
        {
           
            var result = await aboutPageRepository.Update(id , aboutDto);
            return Ok(result);
        }

        [HttpPut("UpdateSection")]
        public async Task<IActionResult> UpdateSection(int id, [FromForm] SectionDto dto)
        {
            var result = await aboutPageRepository.UpdateSection(id, dto);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> UpdateSection(int id)
        {
            var result = await aboutPageRepository.Delete(id);
            return Ok(result);
        }

    }
}
