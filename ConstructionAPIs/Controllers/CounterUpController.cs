using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterUpController : ControllerBase
    {
        private readonly IPublicInterface<counterUpAddDto, CounterUp, counterUpInfoDto> counterUp;

        public CounterUpController(IPublicInterface<counterUpAddDto, CounterUp, counterUpInfoDto> _counterUp)
        {
            counterUp = _counterUp;
        }

        [HttpPost("AddCounterUp")]
        public IActionResult add([FromForm] counterUpAddDto counterUpAddDto)
        {
            if (ModelState.IsValid)
            {
                this.counterUp.Insert(counterUpAddDto);

                return Ok(counterUpAddDto);
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {

            return Ok(counterUp.GetAll());
        }


        [HttpDelete("DeletecounterUp")]
        public IActionResult Delete(int id)
        {
            if (counterUp.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }
        [HttpGet("GetcounterUpByID")]
        public IActionResult GetById(int id)
        {

            if (this.counterUp.getById(id) != null)
                return Ok(this.counterUp.getById(id));
            return BadRequest("Wrong Project ID");
        }

        [HttpPost("EditcounterUp")]
        public IActionResult Edit(int id, [FromForm] counterUpAddDto counterUp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = this.counterUp.Update(id, counterUp);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }
    }
}

