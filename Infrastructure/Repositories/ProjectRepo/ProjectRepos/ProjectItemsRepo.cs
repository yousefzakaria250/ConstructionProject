using AutoMapper;
using Data.Models.Project;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ProjectRepo.ProjectRepos
{
    public class ProjectItemsRepo : IPublicInterface<ProjectItemsAddDto, ProjectItems, ProjectItemsInfoDto>
    {

        private IMapper maperr;
        private ConstructionContext constructionContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProjectItemsRepo(IMapper _mapper, ConstructionContext _constructionContext, IWebHostEnvironment _webHostEnvironment)
        {
            this.constructionContext = _constructionContext;
            webHostEnvironment = _webHostEnvironment;
            this.maperr = _mapper;
        }
        public bool Delete(int id)
        {
            try
            {
                ProjectItems? item = constructionContext.ProjectItems.FirstOrDefault(p => p.Id == id);
                if (item == null)
                    return false;
                else
                {
                    constructionContext.ProjectItems.Remove(item);
                    constructionContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        
        }

        public IEnumerable<ProjectItemsInfoDto> GetAll()
        {
           List<ProjectItems> ProjectItemsDb= constructionContext.ProjectItems.ToList();
            List<ProjectItemsInfoDto> projectItemsInfoDtos = new List<ProjectItemsInfoDto>(); 
            foreach(var item in ProjectItemsDb)
            {
                ProjectItemsInfoDto projectItemsInfo = new ProjectItemsInfoDto();
                projectItemsInfo.title = item.title;
                projectItemsInfo.desc1 = item.desc1;
                projectItemsInfo.desc2 = item.desc2;
                projectItemsInfo.image = item.image;
                projectItemsInfo.Id = item.Id;
                projectItemsInfoDtos.Add(projectItemsInfo);
            }
            return projectItemsInfoDtos;
        }

        public ProjectItemsInfoDto getById(int id)
        {
            var res = this.constructionContext.ProjectItems
                 .FirstOrDefault(prop => prop.Id == id)!;
            if (res == null)
                return null;
            ProjectItemsInfoDto projectItems = new ProjectItemsInfoDto();
            projectItems.desc1 = res.desc1;
            projectItems.desc2 = res.desc2;
            projectItems.Id = res.Id;
            projectItems.image = res.image;
            projectItems.title = res.title;
            return projectItems;

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
        public ProjectItems Insert(ProjectItemsAddDto entity)
        {

            var data = maperr.Map<ProjectItems>(entity);
            if (data != null)
            {
                constructionContext.Add(data);
                constructionContext.SaveChanges();
                return data;
            }
            return null;
        }

        public ProjectItems Update(int id, ProjectItemsAddDto entity)
        {

            ProjectItems projectPage = constructionContext.ProjectItems.FirstOrDefault(p => p.Id == id);//getById(id);
            if (projectPage != null)
            {
                var data = maperr.Map(entity, projectPage, opt => opt.AfterMap((src,
                     dest) =>
                {
                    if (src.image.FileName!="")
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
