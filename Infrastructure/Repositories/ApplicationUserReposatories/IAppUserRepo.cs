using Data.Models.AppUser;
using Infrastructure.Dtos.ApplicationUsersDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ApplicationUserReposatories
{
    public interface IAppUserRepo
    {
        public Task<AuthenticationModel> RegisetrAsync(RegisterDto userDTO);
        public  Task<JwtSecurityToken> LoginWithGoogle(string credential);
       // public Task<AuthenticationModel> Login(LoginDto userDto);
    }
}
