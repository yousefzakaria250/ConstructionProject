using AutoMapper;
using Data.Models.HomePAge;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HomeRepos
{
    public class SliderRepo: IPublicInterface<SliderAddDto, slider, SliderInfoDto>
    {
        private readonly IMapper mapper;
        private readonly ConstructionContext constructionContext;

        public SliderRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            mapper = _mapper;
            constructionContext = _constructionContext;
        }

        public bool Delete(int id)
        {
            try
            {
                slider? item = constructionContext.sliders.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.sliders.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<SliderInfoDto> GetAll()
        {
            List<slider> counterDb = constructionContext.sliders.ToList();
            List<SliderInfoDto> counterInfoDtos = new List<SliderInfoDto>();
            foreach (var item in counterDb)
            {
                SliderInfoDto counterInfoDto = new SliderInfoDto();
                counterInfoDto.Id = item.Id;
                counterInfoDto.desc = item.desc;
                counterInfoDto.title = item.Title;
                counterInfoDto.BgImage = item.BgImage;

                counterInfoDtos.Add(counterInfoDto);
            }
            return counterInfoDtos;
        }

        public SliderInfoDto getById(int id)
        {
            var res = this.constructionContext.sliders
              .FirstOrDefault(prop => prop.Id == id)!;
            if (res == null)
                return null;
            SliderInfoDto counter = new SliderInfoDto();
            counter.desc = res.desc;
            counter.Id = res.Id;
            counter.BgImage = res.BgImage;
            counter.title = res.Title;
            return counter;
        }

        public slider Insert(SliderAddDto entity)
        {
            var data = mapper.Map<slider>(entity);
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
                "Content", "images", "slider", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            await image.CopyToAsync(fs);
        }
        public slider Update(int id, SliderAddDto entity)
        {
            slider slider = constructionContext.sliders.FirstOrDefault(p => p.Id == id);//getById(id);
            if (slider != null)
            {
                var data = mapper.Map(entity, slider, opt => opt.AfterMap((src,
                     dest) =>
                {
                    //if (entity.icon !=null)
                    //{
                    using var memoryStream = new MemoryStream();
                    src.BgImage.CopyTo(memoryStream);
                    var ImageGuid = new Guid();
                    uploadImage(src.BgImage, ImageGuid);
                    dest.BgImage = ImageGuid.ToString() + "_" + src.BgImage.FileName;
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
