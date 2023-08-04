using AutoMapper;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProjectRepo.ProjectRepos
{
    public class ProjectPageRepo : IPublicInterface<ProjectPageAddDto, ProjectPage, ProjectPageInfoDto>
    {
        private IMapper maperr;
        private ConstructionContext constructionContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProjectPageRepo(IMapper _mapper, ConstructionContext _constructionContext, IWebHostEnvironment _webHostEnvironment)
        {
            maperr = _mapper;
            constructionContext = _constructionContext;
            webHostEnvironment = _webHostEnvironment;
        }
        //public IEnumerable<ProjectPage> GetAll()
        //{

        //     IEnumerable<ProjectPage> c= this.constructionContext.ProjectPage.Include(p=>p.project.projects).ToList();
        //    foreach(ProjectPage item in c)
        //    {
        //        ProjectPage project=new ProjectPage();
        //        project.bg=item.bg;

        //        project.header=item.header;


        //        foreach(var c2 in c.Where(x=>x.Id==item.project.ProjectPAgeId))
        //        {
        //          // project.project.Page=c2.project.Page;
        //           project.project.title = c2.project.title;

        //            foreach(var it in c2.project.projects) {
        //                ProjectItems its = new ProjectItems();
        //                its.title=it.title;
        //                its.desc1=it.desc1;
        //                its.desc2 = it.desc2;
        //                its.image=it.image;
        //                project.project.projects.Add(its);
        //            }
        //        }
        //    }

        //    return c;
        //}
        public ProjectPageInfoDto getById(int id)
        {
            var projectPage = constructionContext.ProjectPage
         .Include(p => p.project)
          .ThenInclude(p => p.projects)
         .FirstOrDefault(p => p.Id == id);
            if (projectPage.project != null)
            {
                var projectitemsdto = projectPage.project.projects.Select(pi => new ProjectItemsInfoDto
                {
                    // id = pi.id,
                    image = pi.image,
                    desc1 = pi.desc1,
                    title = pi.title,
                    desc2 = pi.desc2
                });
                var projectdto = new ProjectInfoDto
                {
                    title = projectPage.project.title,
                    projectItems = projectitemsdto.ToList()
                };

                var projectpagedto = new ProjectPageInfoDto
                {
                    header = projectPage.header,
                    bg = projectPage.bg,
                    projectInfoDto = projectdto
                };
                return projectpagedto;
            }


            var projectpagedto2 = new ProjectPageInfoDto
            {
                header = projectPage.header,
                bg = projectPage.bg,
                projectInfoDto=null
            };
            return projectpagedto2;
        }

        public IEnumerable<ProjectPageInfoDto> GetAll()
        {
            IEnumerable<ProjectPageInfoDto> projectPages = constructionContext.ProjectPage
          .Include(p => p.project)
         .ThenInclude(p => p.projects)
                .Select(p => new

                    ProjectPageInfoDto
                {
                    header = p.header,
                    bg = p.bg,
                    Id=p.Id,
                    projectInfoDto = new ProjectInfoDto
                    {
                        title = p.project.title,
                        projectItems = p.project.projects.Select(pi => new ProjectItemsInfoDto
                        {
                            Id = pi.Id,
                            image = pi.image,
                            desc1 = pi.desc1,
                            title = pi.title,
                            desc2 = pi.desc2,
                        }).ToList()
                    }

                }).ToList();
            return projectPages;
        }
        public ProjectPage Insert(ProjectPageAddDto entity)
        {
            var data = maperr.Map<ProjectPage>(entity);
           if (data != null)
             {
               
              //  ProjectPage projectPage = new ProjectPage();
               // var gu = new Guid();
             // uploadImage(entity.bgImage,gu);
                constructionContext.Add(data);
                //projectPage.bg = gu.ToString() + "_" + entity.bgImage.FileName;
                //projectPage.header = entity.header;
                //constructionContext.Add(projectPage);
                constructionContext.SaveChanges();
            //return projectPage;
               return data;
            }
            return null;
        }
        public async void uploadImage(IFormFile image, Guid imageId)
        {

            //string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "ProductsImages");
            //string imageName = imageId.ToString() + "_" + image.FileName;
            //string filePath = Path.Combine(uploadFolder, imageName);
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    await image.CopyToAsync(fileStream);
            //    fileStream.Close();
            //}
            string NewName = Guid.NewGuid().ToString() + image.FileName;

            FileStream fs = new FileStream(
               Path.Combine(Directory.GetCurrentDirectory(),
                "Content", "images", "Section", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
           await image.CopyToAsync(fs);
        }
        public ProjectPage Update(int id, ProjectPageAddDto entity)
        {
            ProjectPage projectPage = constructionContext.ProjectPage.FirstOrDefault(p => p.Id == id);//getById(id);
            if (projectPage != null)
            {
                var data = maperr.Map(entity, projectPage, opt => opt.AfterMap((src,
                     dest) =>
                 {
                     if (src.bgImage.FileName != "")
                     {
                         using var memoryStream = new MemoryStream();
                         src.bgImage.CopyTo(memoryStream);
                         var ImageGuid = new Guid();
                         uploadImage(src.bgImage, ImageGuid);
                         dest.bg = ImageGuid.ToString() + "_" + src.bgImage.FileName;
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
                ProjectPage? item = constructionContext.ProjectPage.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.ProjectPage.Remove(item);
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
