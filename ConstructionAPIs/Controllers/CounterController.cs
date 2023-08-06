using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly IPublicInterface<CounterAddDto, Counter, CounterInfoDto> counterItemsRepo;

        public CounterController(IPublicInterface<CounterAddDto, Counter, CounterInfoDto> _counterItemsRepo)
        {
            counterItemsRepo = _counterItemsRepo;
        }

        [HttpPost("AddCounterItems")]
        public IActionResult add([FromForm] CounterAddDto counterAddDto)
        {
            if (ModelState.IsValid)
            {
                Counter projectPage = this.counterItemsRepo.Insert(counterAddDto);
                if (projectPage != null)
                    return Ok(projectPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpPost("EditCounter")]
        public IActionResult Edit(int id, [FromForm] CounterAddDto counterAddDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Counter newProjectPage = this.counterItemsRepo.Update(id, counterAddDto);
            if (newProjectPage != null)
                return Ok(newProjectPage);
            return BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult Get(string Lang)
        {
            return Ok(counterItemsRepo.GetAll(Lang));
        }
        [HttpGet("GetcounterByID")]
        public IActionResult GetById(int id,string Lang)
        {
            if (id != null)
                return Ok(this.counterItemsRepo.getById(id, Lang));
            return BadRequest("ProjectItem  ID is Missing");
        }

        [HttpDelete("DeletecounterByID")]
        public IActionResult Delete(int id)
        {
            if (counterItemsRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }


    }
}
