using AutoMapper;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Infrastructure.Repositories.SolutionRepos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SolutionRepos
{
    public class SolutionPageRepo : IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto>
    {
        private IMapper maperr;
        private ConstructionContext constructionContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SolutionPageRepo(IMapper _mapper, ConstructionContext _constructionContext, IWebHostEnvironment _webHostEnvironment)
        {
            maperr = _mapper;
            constructionContext = _constructionContext;
            webHostEnvironment = _webHostEnvironment;
        }
      
        public SolutionPageInfoDto getById(int id,string Lang)
        {
            if (Lang == "en")
            {
                var SolutionPage = constructionContext.SolutionPage
         .Include(p => p.solution)
          .ThenInclude(p => p.solutions)
         .FirstOrDefault(p => p.Id == id);

                var solutionItemsDto = SolutionPage.solution.solutions.Select(pi => new SolutionItemsInfoDto
                {
                    Id = pi.Id,
                    image = pi.image,
                    desc = pi.ENdesc,
                    title = pi.ENtitle,
                }).ToList();
                var solutionDto = new SolutionInfoDto
                {
                    title = SolutionPage.solution.ENtitle,
                    solutionItems = solutionItemsDto
                };

                var SolutionPageDto = new SolutionPageInfoDto
                {
                    header = SolutionPage.ENheader,
                    bg = SolutionPage.bgImage,
                    solutionInfoDto = solutionDto
                };

                return SolutionPageDto;
            }
            else
            {
                var SolutionPage = constructionContext.SolutionPage
         .Include(p => p.solution)
          .ThenInclude(p => p.solutions)
         .FirstOrDefault(p => p.Id == id);

                var solutionItemsDto = SolutionPage.solution.solutions.Select(pi => new SolutionItemsInfoDto
                {
                    Id = pi.Id,
                    image = pi.image,
                    desc = pi.ARdesc,
                    title = pi.ARtitle,
                }).ToList();
                var solutionDto = new SolutionInfoDto
                {
                    title = SolutionPage.solution.ARtitle,
                    solutionItems = solutionItemsDto
                };

                var SolutionPageDto = new SolutionPageInfoDto
                {
                    header = SolutionPage.ARheader,
                    bg = SolutionPage.bgImage,
                    solutionInfoDto = solutionDto
                };

                return SolutionPageDto;
            }
           
        }

        public IEnumerable<SolutionPageInfoDto> GetAll(string Lang)
        { 
            if(Lang=="en"){
                IEnumerable<SolutionPageInfoDto> SolutionPages = constructionContext.SolutionPage
          .Include(p => p.solution)
         .ThenInclude(p => p.solutions)
                .Select(p => new

                    SolutionPageInfoDto
                {
                    header = p.ENheader,
                    bg = p.bgImage,
                    solutionInfoDto = new SolutionInfoDto
                    {
                        title = p.solution.ENtitle,
                        solutionItems = p.solution.solutions.Select(pi => new SolutionItemsInfoDto
                        {
                            Id = pi.Id,
                            image = pi.image,
                            desc = pi.ENdesc,
                            title = pi.ENtitle,
                        }).ToList()
                    }

                }).ToList();
                return SolutionPages;
            }

            else {
                IEnumerable<SolutionPageInfoDto> SolutionPages = constructionContext.SolutionPage
          .Include(p => p.solution)
         .ThenInclude(p => p.solutions)
                .Select(p => new

                    SolutionPageInfoDto
                {
                    header = p.ENheader,
                    bg = p.bgImage,
                    solutionInfoDto = new SolutionInfoDto
                    {
                        title = p.solution.ARtitle,
                        solutionItems = p.solution.solutions.Select(pi => new SolutionItemsInfoDto
                        {
                            Id = pi.Id,
                            image = pi.image,
                            desc = pi.ARdesc,
                            title = pi.ARtitle,
                        }).ToList()
                    }

                }).ToList();
                return SolutionPages;
            }
            
        }
        public async void uploadImage(IFormFile image, Guid imageId)
        {

            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string imageName = imageId.ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadFolder, imageName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
                fileStream.Close();
            }
        }

        public solutionPage Insert(SolutionPageAddDto entity)
        {
            var data = maperr.Map<solutionPage>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public solutionPage Update(int id, SolutionPageAddDto entity)
        {
            solutionPage SolutionPage = constructionContext.SolutionPage.FirstOrDefault(p => p.Id == id);//getById(id);
            if (SolutionPage != null)
            {
                var data = maperr.Map(entity, SolutionPage, opt => opt.AfterMap((src,
                     dest) =>
                {
                    if (src.bgImage != null)
                    {
                        using var memoryStream = new MemoryStream();
                        src.bgImage.CopyTo(memoryStream);
                        var ImageGuid = new Guid();
                        uploadImage(src.bgImage, ImageGuid);
                        dest.bgImage = ImageGuid.ToString() + "_" + src.bgImage.FileName;
                    }
                }));
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                solutionPage? item = constructionContext.SolutionPage.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.SolutionPage.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
