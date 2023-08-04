using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly IPublicInterface<SliderAddDto, slider, SliderInfoDto> sliderRepo;

        public SliderController(IPublicInterface<SliderAddDto, slider, SliderInfoDto> _sliderRepo)
        {
            sliderRepo = _sliderRepo;
        }

        [HttpPost("Addslider")]
        public IActionResult add([FromForm] SliderAddDto sliderAddDto)
        {
            if (ModelState.IsValid)
            {
                slider _slider = this.sliderRepo.Insert(sliderAddDto);
                if (_slider != null)
                    return Ok(_slider);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(sliderRepo.GetAll());
        }
        [HttpGet("GetSliderByID")]
        public IActionResult GetById(int id)
        {
            if (id != null)
                return Ok(this.sliderRepo.getById(id));
            return BadRequest("Project Page ID is Missing");
        }

        [HttpDelete("Deleteslider")]
        public IActionResult Delete(int id)
        {
            if (sliderRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }

        [HttpPost("Editslider")]
        public IActionResult Edit(int id, [FromForm] SliderAddDto slider)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            slider newslider = this.sliderRepo.Update(id, slider);
            if (newslider != null)
                return Ok(newslider);
            return BadRequest();
        }

    }
}
