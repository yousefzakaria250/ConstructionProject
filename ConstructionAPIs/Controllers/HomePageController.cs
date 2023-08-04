using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Dtos.HomeDtos;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.HomeRepos;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IPublicInterface<homePageAddDto, HomePage, HomepageInfoDto> homePageRepo;

        public HomePageController(IPublicInterface<homePageAddDto, HomePage, HomepageInfoDto>  _homeRepo)
        {
            this.homePageRepo = _homeRepo;
        }

        [HttpPost("AddHomePage")]
        public IActionResult add([FromForm] homePageAddDto homeAddDto)
        {
            if (ModelState.IsValid)
            {
                HomePage projectPage = this.homePageRepo.Insert(homeAddDto);
                if (projectPage != null)
                    return Ok(projectPage);

                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(homePageRepo.GetAll());
        }
        [HttpGet("GetProjectPageByID")]
        public IActionResult GetById(int id)
        {
            if (id >=0)
                return Ok(this.homePageRepo.getById(id));
            return BadRequest("Project Page ID is Missing");
        }

        [HttpDelete("DeleteProjectPage")]
        public IActionResult Delete(int id)
        {
            if (homePageRepo.Delete(id))
            {
                return StatusCode(201, "تم الحذف بنجاح");
            }
            return BadRequest("لم يتم الحذف حاول مره اخري");
        }

        [HttpPost("EditProjectPage")]
        public IActionResult Edit(int id, [FromForm] homePageAddDto project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            HomePage newProjectPage = this.homePageRepo.Update(id, project);
            if (newProjectPage != null)
                return Ok(newProjectPage);
            return BadRequest();
        }

    }
}
