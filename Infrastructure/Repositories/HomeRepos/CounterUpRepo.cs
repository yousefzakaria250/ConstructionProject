using AutoMapper;
using Data.Models.HomePAge;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HomeRepos
{
    public class CounterUpRepo : IPublicInterface<counterUpAddDto, CounterUp, counterUpInfoDto>
    {
        private readonly IMapper mapper;
        private readonly ConstructionContext constructionContext;

        public CounterUpRepo(IMapper _mapper, ConstructionContext _constructionContext)
        {
            mapper = _mapper;
            constructionContext = _constructionContext;
        }
        public bool Delete(int id)
        {
           
            try
            {
                CounterUp? item = constructionContext.counterUps.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.counterUps.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    public IEnumerable<counterUpInfoDto> GetAll(string Lang)
        {
            if (Lang == "en")
            {
                IEnumerable<counterUpInfoDto> counterUps = constructionContext.counterUps
            .Include(p => p.Counter)
                  .Select(p => new

                      counterUpInfoDto
                  {
                      Id = p.Id,
                      Bg = p.BgImage,

                      Counter = p.Counter.Select(pi => new CounterInfoDto
                      {
                          Id = pi.Id,

                          desc = pi.ENdesc,
                          count = pi.count,
                          icon = pi.icon,
                      }).ToList()
                  }).ToList();
                return counterUps;
            }
            else
            {
                IEnumerable<counterUpInfoDto> counterUps = constructionContext.counterUps
                .Include(p => p.Counter)
               .Select(p => new

                   counterUpInfoDto
               {
                   Id = p.Id,
                   Bg = p.BgImage,

                   Counter = p.Counter.Select(pi => new CounterInfoDto
                   {
                       Id = pi.Id,
                       desc = pi.ARdesc,
                       count = pi.count,
                       icon = pi.icon,
                   }).ToList()
               }).ToList();
                return counterUps;
            }

        }

        public counterUpInfoDto getById(int id,string Lang)
        {
            if (Lang == "en")
            {
                var counterUp = constructionContext.counterUps
                .Include(p => p.Counter)

                .FirstOrDefault(p => p.Id == id);
                if (counterUp != null)
                {
                    if (counterUp.Counter.Count != 0)
                    {
                        var counterInfoDto = counterUp.Counter.Select(pi => new CounterInfoDto
                        {
                            Id = pi.Id,
                            desc = pi.ENdesc,
                            count = pi.count,
                            icon = pi.icon,
                        }).ToList();
                        var counterUpInfoDto = new counterUpInfoDto
                        {
                            Bg = counterUp.BgImage

                        };
                        return counterUpInfoDto;
                    }
                    var counterUpInfoDto1 = new counterUpInfoDto
                    {
                        Bg = counterUp.BgImage

                    };

                    return counterUpInfoDto1;
                }
            }
            else
            {
                var counterUp = constructionContext.counterUps
                .Include(p => p.Counter)

                .FirstOrDefault(p => p.Id == id);
                if (counterUp != null)
                {
                    if (counterUp.Counter.Count != 0)
                    {
                        var counterInfoDto = counterUp.Counter.Select(pi => new CounterInfoDto
                        {
                            Id = pi.Id,
                            desc = pi.ARdesc,
                            count = pi.count,
                            icon = pi.icon,
                        }).ToList();
                        var counterUpInfoDto = new counterUpInfoDto
                        {
                            Bg = counterUp.BgImage

                        };
                        return counterUpInfoDto;
                    }
                    var counterUpInfoDto1 = new counterUpInfoDto
                    {
                        Bg = counterUp.BgImage

                    };

                    return counterUpInfoDto1;
                }
                return null;
            }
            return null;
        }

        
            public CounterUp Insert(counterUpAddDto entity)
        {
            var data = mapper.Map<CounterUp>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null!;
        }

        public CounterUp Update(int id, counterUpAddDto entity)
        {
            CounterUp OldcounterUp = constructionContext.counterUps.FirstOrDefault(p => p.Id == id)!;//getById(id);
            var data = mapper.Map(entity, OldcounterUp);
            if (data != null)
            {
                constructionContext.SaveChanges();
                return data;
            }
            return null!;
        }
    }
}
