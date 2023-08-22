using Data.Models.About;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAboutPageRepository
    {
        public Task<dynamic> GetAll(string Lang);
        public Task<dynamic> Insert( AboutDto pageDto);
        public Task<dynamic> InsertSection( SectionDto SectionDto);
        public Task<dynamic> Update(int id , AboutDto dto);
        public Task<AboutPage> Get(int id);
        public Task<dynamic> UpdateSection(int id, SectionDto dto);
        public Task<Section> GetSection(int id);
        public string ConvertImageToString(IFormFile image);
        public Task<AboutPage> Delete(int Id);
    }
}
