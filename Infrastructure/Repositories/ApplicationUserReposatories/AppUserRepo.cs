using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Data.Models.AppUser;
using Google.Apis.Auth;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ApplicationUsersDto;
using Infrastructure.Helper.AppSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Constatnts;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories.ApplicationUserReposatories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly IConfiguration config;
        private readonly RoleManager<IdentityRole> roleManager;
        //   private readonly JWT jwt;
        private readonly ConstructionContext context;
        private readonly IMapper mapper;

        private readonly AppSettings _applicationSettings;
        private readonly HttpClient _httpClient;
        public AppUserRepo(UserManager<ApplicationUser> _userManager, ConstructionContext _context,
                           RoleManager<IdentityRole> _roleManager, IConfiguration _config,
                           IMapper _mapper
                          )
        {
            this.context = _context;
            this.roleManager = _roleManager;
            this.userManger = _userManager;
            this.config = _config;
            this.mapper = _mapper;
        }
        public async Task<AuthenticationModel> RegisetrAsync(RegisterDto userDTO)
        {
            //check if user has email registered before
            if (await userManger.FindByEmailAsync(userDTO.Email) is not null)
                return new AuthenticationModel { Message = "هذا البريد الالكتروني مستخدم من قبل" };
            //check if any user uses the same UserName
            if (await userManger.FindByNameAsync(userDTO.UserName) is not null)
                return new AuthenticationModel { Message = "اسم المستخم موجود بالفعل" };
            //create Application User
            ApplicationUser user = new ApplicationUser();

            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.LastName = userDTO.LastName;
            user.FirstName = userDTO.FirstName;
            user.Password = userDTO.Password;
            string NewName = Guid.NewGuid().ToString() + userDTO!.image!.FileName;

            FileStream fs = new FileStream(
               Path.Combine(Directory.GetCurrentDirectory(),
                "Content", "Images", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            userDTO.image.CopyTo(fs);
            // fs.Close();
            fs.Position = 0;
            user.image = NewName;
            //   var data = mapper.Map<ApplicationUser>(userDTO);
                            //create user in database
            IdentityResult result = await userManger.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                // assign  new user to Role As user
                result = await userManger.AddToRoleAsync(user, "USER");// Roles.USER_ROLE);
                if (!result.Succeeded)
                    return new AuthenticationModel { Message = getErrorsAsString(result) };
                var jwtSecurityToken = await this.CreateJwtToken(user);
                return new AuthenticationModel
                {
                    Email = user.Email,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { Roles.USER_ROLE },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Username = user.UserName
                };
            }

            return new AuthenticationModel { Message = getErrorsAsString(result) };
        }

        private string getErrorsAsString(IdentityResult result)
        {
            string errors = String.Empty;
            foreach (var er in result.Errors)
            {
                errors += er.Description.ToString();
            }
            return errors;
        }

       
        public async Task<JwtSecurityToken> LoginWithGoogle( string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { this._applicationSettings.GoogleClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

            //var user = UserList.Where(x => x.UserName == payload.Name).FirstOrDefault();
            //var user = context.users.Where(x => x.UserName == payload.Name).FirstOrDefault();
            //if (user != null)
            //{
            //    return await CreateJwtToken(user);
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }

        //[HttpPost("LoginWithFacebook")]
        //public async Task<IActionResult> LoginWithFacebook([FromBody] string credential)
        //{
        //    HttpResponseMessage debugTokenResponse = await _httpClient.GetAsync("https://graph.facebook.com/debug_token?input_token=" + credential + $"&access_token={this._applicationSettings.FacebookAppId}|{this._applicationSettings.FacebookSecret}");

        //    var stringThing = await debugTokenResponse.Content.ReadAsStringAsync();
        //    var userOBJK = JsonConvert.DeserializeObject<FBUser>(stringThing);

        //    if (userOBJK.Data.IsValid == false)
        //    {
        //        return Unauthorized();
        //    }

        //    HttpResponseMessage meResponse = await _httpClient.GetAsync("https://graph.facebook.com/me?fields=first_name,last_name,email,id&access_token=" + credential);
        //    var userContent = await meResponse.Content.ReadAsStringAsync();
        //    var userContentObj = JsonConvert.DeserializeObject<FBUserInfo>(userContent);

        //    var user = UserList.Where(x => x.UserName == userContentObj.Email).FirstOrDefault();

        //    if (user != null)
        //    {
        //        return Ok(JWTGenerator(user));
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //public dynamic JWTGenerator(ApplicationUser user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName), new Claim(ClaimTypes.Role, user.Role),
        //                new Claim(ClaimTypes.DateOfBirth, user.BirthDay)}),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var encrypterToken = tokenHandler.WriteToken(token);

        //    SetJWT(encrypterToken);

        //    var refreshToken = GenerateRefreshToken();

        //    SetRefreshToken(refreshToken, user);

        //    return new { token = encrypterToken, username = user.UserName };
        //}




        public async Task<AuthenticationModel> Login(LoginDto userDto)
        {
            var AuthModel = new AuthenticationModel();
            ApplicationUser user = await userManger.FindByNameAsync(userDto.UserName);
            if (user == null)
            {
                AuthModel.Message = "اسم المستخدم غير صحيح";
                return AuthModel;
            }
            else
            {
                bool found = await userManger.CheckPasswordAsync(user, userDto.Password);
                if (found)
                {
                    var myToken = await CreateJwtToken(user);

                    var roleList = await userManger.GetRolesAsync(user);
                    AuthModel.IsAuthenticated = true;
                    AuthModel.Token = new JwtSecurityTokenHandler().WriteToken(myToken);
                    AuthModel.Email = user.Email;
                    AuthModel.Username = user.UserName;
                    AuthModel.Roles = roleList.ToList();
                    AuthModel.ExpiresOn = myToken.ValidTo;
                    return AuthModel;
                }
                else
                {
                    AuthModel.Message = "كلمة المرور غير صحيحه";
                    return AuthModel;
                }
            }
        }



        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            //get claims
            var UserClaims = await this.userManger.GetClaimsAsync(user);

            //get Role
            var roles = await userManger.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            }.Union(UserClaims).Union(roleClaims);
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:secret"]));
            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //create Token
            JwtSecurityToken myToken = new JwtSecurityToken(
            issuer: config["JWT:ValidIssuer"],
            audience: config["JWT:ValidAudiance"],
            claims: claims,
            expires: DateTime.Now.AddDays(int.Parse(config["JWT:DurationInDays"])),
            signingCredentials: signingCred
         );
            return myToken;
        }
    }
}
