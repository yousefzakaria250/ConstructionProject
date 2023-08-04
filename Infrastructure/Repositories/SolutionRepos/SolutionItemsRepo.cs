using AutoMapper;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.SolutionRepos
{
    public class SolutionItemsRepo: IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto>
    {

            private IMapper maperr;
            private ConstructionContext constructionContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SolutionItemsRepo(IMapper _mapper, ConstructionContext _constructionContext,
                IWebHostEnvironment _webHostEnvironment)
            {
                this.constructionContext = _constructionContext;
            webHostEnvironment = _webHostEnvironment;
            this.maperr = _mapper;
            }

            public bool Delete(int id)
            {
                try
                {
                    solutionItems? item = constructionContext.solutionItems.FirstOrDefault(p => p.Id == id);
                    if (item == null)
                        return false;
                    else
                    {
                        constructionContext.solutionItems.Remove(item);
                        constructionContext.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

            }

            public IEnumerable<SolutionItemsInfoDto> GetAll()
            {
                List<solutionItems> solutionItemsDb = constructionContext.solutionItems.ToList();
                List<SolutionItemsInfoDto> SolutionItemsInfoDtos = new List<SolutionItemsInfoDto>();
                foreach (var item in solutionItemsDb)
                {
                    SolutionItemsInfoDto solutiontemsInfo = new SolutionItemsInfoDto();
                    solutiontemsInfo.title = item.title;
                    solutiontemsInfo.desc = item.desc;
                    solutiontemsInfo.image = item.image;
                    solutiontemsInfo.Id = item.Id;
                    SolutionItemsInfoDtos.Add(solutiontemsInfo);
                }
                return SolutionItemsInfoDtos;
            }

            public SolutionItemsInfoDto getById(int id)
            {
                var res = this.constructionContext.solutionItems
                     .FirstOrDefault(prop => prop.Id == id)!;
                if (res == null)
                    return null;
                SolutionItemsInfoDto solutionitems = new SolutionItemsInfoDto();
                solutionitems.desc = res.desc;
                solutionitems.Id = res.Id;
                solutionitems.image = res.image;
                solutionitems.title = res.title;
                return solutionitems;

            }


            public solutionItems Insert(SolutionItemsAddDto entity)
            {

                var data = maperr.Map<solutionItems>(entity);
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

            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "ProductsImages");
            string imageName = imageId.ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadFolder, imageName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
                fileStream.Close();
            }
        }

        public solutionItems Update(int id, SolutionItemsAddDto entity)
            {

                solutionItems projectPage = constructionContext.solutionItems.FirstOrDefault(p => p.Id == id);//getById(id);
                if (projectPage != null)
                {
                    var data = maperr.Map(entity, projectPage, opt => opt.AfterMap((src,
                         dest) =>
                    {
                        if (src.image.FileName != "")
                        {
                            using var memoryStream = new MemoryStream();
                            src.image.CopyTo(memoryStream);
                            var ImageGuid = new Guid();
                            uploadImage(src.image, ImageGuid);
                            dest.image = ImageGuid.ToString() + "_" + src.image.FileName;
                        }
                    }));
                    constructionContext.SaveChanges();
                    return data;
                }
                return null;
            }
        }
    }

