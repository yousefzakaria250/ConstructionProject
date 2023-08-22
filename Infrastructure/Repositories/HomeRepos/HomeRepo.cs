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
using Data.Models.About;
using Microsoft.AspNetCore.Mvc.Razor;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Http;

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
            HomePage? homePage = constructionContext.homePages.FirstOrDefault(h => h.Id == id);
            if (homePage == null)
                return false;
            constructionContext.homePages.Remove(homePage);
            constructionContext.SaveChanges();
            return true;
        }

        public IEnumerable<HomepageInfoDto> GetAll(string Lang)
        {

            var res = constructionContext.homePages.ToList();
            List<HomepageInfoDto> homepageList = new List<HomepageInfoDto>();
            foreach (var item in res)
            {
                HomepageInfoDto homepage = new HomepageInfoDto();
                homepage.logo = item.logoImage!;
                homepageList.Add(homepage);

            }
            return homepageList;

            //    if (Lang == "en")
            //    {
            //        var res = constructionContext.homePages.Include(s => s.sliders)
            //            .Include(cup => cup.counterUp).ThenInclude(c => c.Counter)
            //            .Include(ser => ser.services).ThenInclude(sec => sec.Service)
            //            .Include(projectPage => projectPage.project).ThenInclude(project => project.project)
            //            .Include(about => about.about).ThenInclude(sec => sec.Section)
            //            .Select(homePage => new HomepageInfoDto
            //            {
            //                // Id = homePage.Id,
            //                logo = homePage.logoImage,
            //                slider = homePage.sliders.Select(s => new SliderInfoDto
            //                {
            //                    Id = s.Id,
            //                    desc = s.ENdesc,
            //                    title = s.ENTitle,
            //                    bg = s.BgImage,
            //                }).ToList(),
            //                counterUp = new counterUpInfoDto
            //                {
            //                   // Id = homePage.counterUp.Id,
            //                    Bg = homePage.counterUp.BgImage,
            //                    Counter = homePage.counterUp.Counter.Select(cou =>
            //                        new CounterInfoDto
            //                        {
            //                            Id = cou.Id,
            //                            count = cou.count,
            //                            desc = cou.ENdesc,
            //                            icon = cou.icon
            //                        }).ToList()
            //                },
            //                project = new ProjectInfoDto
            //                {
            //                    title = homePage.project.ENheader,
            //                    projects = homePage.project.project.projects.Select(pt => new Dtos.ProjectItemsDto.ProjectItemsInfoDto
            //                    {
            //                        Id = pt.Id,
            //                        image = pt.image,
            //                        desc1 = pt.ENdesc1,
            //                        desc2 = pt.ENdesc2,
            //                        title = pt.ENtitle,

            //                    }).ToList()
            //                },
            //                about = new HomeAboutInfoDto
            //                {
            //                    header = homePage.about.header,
            //                    section = new Dtos.HomeDtos.Section
            //                    {
            //                        title = homePage.about.Section.title,
            //                        desc = homePage.about.Section.desc,
            //                        image = homePage.about.Section.image
            //                    }
            //                },
            //                services = new ServiceInfoDto
            //                {
            //                    header = homePage.services.header,
            //                    section = homePage.services.Service.serviceItems.Select(z => new HomeServiceSectionDto
            //                    {
            //                       Id = z.Id,
            //                        title = z.title,
            //                        desc = z.desc,
            //                      //  icon=z.icon
            //                    }).ToList()
            //                }
            //            });
            //        return res;
            //    }

            //    else  
            //    {
            //        var res = constructionContext.homePages.Include(s => s.sliders)
            //            .Include(cup => cup.counterUp).ThenInclude(c => c.Counter)
            //            .Include(ser => ser.services).ThenInclude(sec => sec.Service)
            //            .Include(projectPage => projectPage.project).ThenInclude(project => project.project)
            //            .Include(about => about.about).ThenInclude(sec => sec.Section)
            //            .Select(homePage => new HomepageInfoDto
            //            {
            //                // Id = homePage.Id,
            //                logo = homePage.logoImage,
            //                slider = homePage.sliders.Select(s => new SliderInfoDto
            //                {
            //                    Id = s.Id,
            //                    desc = s.ARdesc,
            //                    title = s.ARdesc,
            //                    bg = s.BgImage,
            //                }).ToList(),
            //                counterUp = new counterUpInfoDto
            //                {
            //                    Id = homePage.counterUp.Id,
            //                    Bg = homePage.counterUp.BgImage,
            //                    Counter = homePage.counterUp.Counter.Select(cou =>
            //                        new CounterInfoDto
            //                        {
            //                            Id = cou.Id,
            //                            count = cou.count,
            //                            desc = cou.ARdesc,
            //                            icon = cou.icon
            //                        }).ToList()
            //                },
            //                project = new ProjectInfoDto
            //                {
            //                    title = homePage.project.ENheader,
            //                    projects = homePage.project.project.projects.Select(pt => new Dtos.ProjectItemsDto.ProjectItemsInfoDto
            //                    {
            //                        Id = pt.Id,
            //                        image = pt.image,
            //                        desc1 = pt.ARdesc1,
            //                        desc2 = pt.ARdesc2,
            //                        title = pt.ARtitle,

            //                    }).ToList()
            //                },
            //                about = new HomeAboutInfoDto
            //                {
            //                    header = homePage.about.header,
            //                    section = new Dtos.HomeDtos.Section
            //                    {
            //                        title = homePage.about.Section.TitleAR,
            //                        desc = homePage.about.Section.DescAR,
            //                        image = homePage.about.Section.image
            //                    }
            //                },
            //                services = new ServiceInfoDto
            //                {
            //                    header = homePage.services.header,
            //                    section = homePage.services.Service.serviceItems.Select(z => new HomeServiceSectionDto
            //                    {
            //                        Id = z.Id,
            //                        title = z.titleAR,
            //                        desc = z.descAR,
            //                        //icon=z.icon
            //                    }).ToList()
            //                }
            //            });
            //        return res;
            //    }
        }
        public HomepageInfoDto getById(int id,string lang)
        {
            HomePage? homePage=  constructionContext.homePages.FirstOrDefault(h => h.Id == id);
            if (homePage == null)
            {
                return null;
            }
                HomepageInfoDto homePageInfoDto = new HomepageInfoDto();
                homePageInfoDto.logo = homePage.logoImage;
                return homePageInfoDto;
            
            
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
        public async void uploadImage(IFormFile image, Guid imageId)
        {
            string NewName = Guid.NewGuid().ToString() + image.FileName;

            FileStream fs = new FileStream(
               Path.Combine(Directory.GetCurrentDirectory(),
                "Content", "Images", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            await image.CopyToAsync(fs);
        }
        public HomePage Update(int id, homePageAddDto entity)
        {
            HomePage? homePage =constructionContext.homePages.FirstOrDefault(h=>h.Id==id);
            if(homePage == null)
            {
                return null;
            }
            // var data=mapper.Map<HomePage>(entity);
            if (entity.Logo.FileName != null)
            {
                using var memoryStream = new MemoryStream();
                entity.Logo.CopyTo(memoryStream);
                var ImageGuid = new Guid();
                uploadImage(entity.Logo, ImageGuid);
                homePage.logoImage = ImageGuid.ToString() + "_" + entity.Logo.FileName;
                constructionContext.SaveChanges();
                return homePage;
            }
            
            
            return null;

        }
    }
}
