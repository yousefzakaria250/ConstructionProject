using AutoMapper;
using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.HomeDtos;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Dtos;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.ProjectDto;

namespace Infrastructure.Repositories.HomeRepos
{
    public class homePageRepo : IPublicInterface<homePageAddDto, HomePage, HomepageInfoDto>
    {
        private readonly IMapper mapper;
        private readonly ConstructionContext constructionContext;

        public homePageRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            mapper = _mapper;
            constructionContext = _constructionContext;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HomepageInfoDto> GetAll()
        {
            var res = constructionContext.homePages.ToList();

            
            List<HomepageInfoDto> homepageList=new List<HomepageInfoDto>();
            foreach (var item in res)
            {
                HomepageInfoDto homepage = new HomepageInfoDto();
                homepage.logoImage = item.logoImage!;
                homepageList.Add(homepage);
                
            }
            return homepageList;
            
            //var res = constructionContext.homePages.Include(s => s.sliders)
            //    .Include(cup => cup.counterUp).ThenInclude(c => c.Counter)
            //    .Include(ser => ser.services).ThenInclude(sec => sec.Service)
            //    .Include(projectPage => projectPage.project).ThenInclude(project => project.project)
            //    .Include(about => about.about).ThenInclude(sec => sec.Section)
            //    .Select(H => new HomepageInfoDto
            //    {
            //        Id = H.Id,
            //        logoImage = H.logoImage,
            //        sliders = H.sliders.Select(s => new SliderInfoDto
            //        {
            //            Id = s.Id,
            //            desc = s.desc,
            //            title = s.Title,
            //            BgImage = s.BgImage,
            //        }).ToList(),
            //        counterUp = new counterUpInfoDto
            //        {
            //            Id = H.counterUp.Id,
            //            BgImage = H.counterUp.BgImage,
            //            Counter = H.counterUp.Counter.Select(cou =>
            //                new CounterInfoDto
            //                {
            //                    Id = cou.Id,
            //                    count = cou.count,
            //                    desc = cou.desc,
            //                    icon = cou.icon
            //                }).ToList()
            //        },
            //        project = new ProjectInfoDto
            //        {
            //            title = H.project.header,
            //            projectItems = H.project.project.projects.Select(pt => new Dtos.ProjectItemsDto.ProjectItemsInfoDto)
            //        }

            //    }); ;
            //return res;
        }

        public HomepageInfoDto getById(int id)
        {
            throw new NotImplementedException();
        }

        public HomePage Insert(homePageAddDto entity)
        {
            var data = mapper.Map<HomePage>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();

                return data;
            }
            return null;
        }

        public HomePage Update(int id, homePageAddDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
