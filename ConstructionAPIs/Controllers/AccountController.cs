using Google.Apis.Auth;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ApplicationUsersDto;
using Infrastructure.Helper.AppSettings;
using Infrastructure.Repositories.ApplicationUserReposatories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace ConstructionAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserRepo AppRepo;
      
       // private readonly ConstructionContext constructionContext;
        public AccountController(IAppUserRepo appUserRepo)//, ConstructionContext _constructionContext)
        {
                this.AppRepo = appUserRepo;
                //this.constructionContext = _constructionContext;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var AuthResponseData = await AppRepo.RegisetrAsync(registerDto);
                if(AuthResponseData != null)
                {
                    return Ok(AuthResponseData);
                }
                return BadRequest(AuthResponseData.Message);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            if (ModelState.IsValid)
            {
                var result = await AppRepo.LoginWithGoogle(credential);
                if (result != null)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest();
                }
            }
            else {  return BadRequest(ModelState); }
          
        }

    }
}
