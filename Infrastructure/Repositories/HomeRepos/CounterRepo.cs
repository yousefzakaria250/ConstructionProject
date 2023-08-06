using AutoMapper;
using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HomeRepos
{
    public class CounterRepo : IPublicInterface<CounterAddDto, Counter, CounterInfoDto>
    {
        private readonly IMapper mapper;
        private readonly ConstructionContext constructionContext;

        public CounterRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            mapper = _mapper;
            constructionContext = _constructionContext;
        }
        public bool Delete(int id)
        {
            try
            {
                Counter? item = constructionContext.counters.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.counters.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
               

        }

        public IEnumerable<CounterInfoDto> GetAll(string Lang)
        {
            
            List<Counter> counterDb = constructionContext.counters.ToList();
            List<CounterInfoDto> counterInfoDtos = new List<CounterInfoDto>();
            foreach (var item in counterDb)
            {
                CounterInfoDto counterInfoDto = new CounterInfoDto();
                counterInfoDto.Id = item.Id;
                if (Lang == "en")
                {
                    counterInfoDto.desc = item.ENdesc;
                }
                else
                {
                    counterInfoDto.desc = item.ARdesc;
                }
                counterInfoDto.count = item.count;
                counterInfoDto.icon = item.icon;

                counterInfoDtos.Add(counterInfoDto);
            }
            return counterInfoDtos;
        }

        public CounterInfoDto getById(int id,string Lang)
        {
            var res = this.constructionContext.counters
               .FirstOrDefault(prop => prop.Id == id)!;
            if (res == null)
                return null;
            CounterInfoDto counter = new CounterInfoDto();
            if (Lang == "en")
            {
                counter.desc = res.ENdesc;
            }
            else
            {
                counter.desc = res.ARdesc;
            }
            counter.Id = res.Id;
            counter.icon = res.icon;
            counter.count = res.count;
            return counter;
        }

        public Counter Insert(CounterAddDto entity)
        {
            var data = mapper.Map<Counter>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }
        public async void uploadImage(IFormFile image, Guid imageId)
        {  

            string NewName = Guid.NewGuid().ToString() + image.FileName;

            FileStream fs = new FileStream(
               Path.Combine(Directory.GetCurrentDirectory(),
                "Content", "Images", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            await image.CopyToAsync(fs);
        }
        public Counter Update(int id, CounterAddDto entity)
        {
            Counter counter = constructionContext.counters.FirstOrDefault(p => p.Id == id);//getById(id);
            if (counter != null)
            {
                var data = mapper.Map(entity, counter, opt => opt.AfterMap((src,
                     dest) =>
                {
                    //if (entity.icon !=null)
                    //{
                    using var memoryStream = new MemoryStream();
                    src.icon.CopyTo(memoryStream);
                    var ImageGuid = new Guid();
                    uploadImage(src.icon, ImageGuid);
                    dest.icon = ImageGuid.ToString() + "_" + src.icon.FileName;
                    //}
                    //dest.icon = dest.icon;
                }));
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        
    }
    
}
