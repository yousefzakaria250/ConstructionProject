using AutoMapper;
using Data.Models.HomePAge;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.ApplicationUsersDto;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Dtos.HomeDtos;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
       

       
        public DomainProfile() { 
            CreateMap<ProjectPageAddDto, ProjectPage>()
                   .ForMember(dest => dest.bg, opt => opt.MapFrom(src =>
                  uploadImage(src.bgImage)));
                    //Project Mapper
                   CreateMap<ProjectAddDto, Project>();
            //ProjectItems Mapper
            CreateMap<ProjectItemsAddDto, ProjectItems>()
            .ForMember(dest => dest.image, opt => opt.MapFrom(src =>
           uploadImage(src.image)));

            //Solution MApper
            CreateMap<SolutionPageAddDto, solutionPage>()
                  .ForMember(dest => dest.bgImage, opt => opt.MapFrom(src =>
                 uploadImage(src.bgImage)));
            //Project Mapper
            CreateMap<SolutionAddDto, solution>();
            //solutionitems Mapper
            CreateMap<SolutionItemsAddDto, solutionItems>()
            .ForMember(dest => dest.image, opt => opt.MapFrom(src =>
           uploadImage(src.image)));

            //counter Mapper
            CreateMap<CounterAddDto, Counter>()
            .ForMember(dest => dest.icon, opt => opt.MapFrom(src =>
           uploadImage(src.icon)));

            // CounterUp Mapper
            CreateMap<counterUpAddDto, CounterUp>()
           .ForMember(dest => dest.BgImage, opt => opt.MapFrom(src =>
           uploadImage(src.BgImage)));
            //Slider Mapper
            CreateMap<SliderAddDto, slider>()
           .ForMember(dest => dest.BgImage, opt => opt.MapFrom(src =>
          uploadImage(src.BgImage)));
            //HomePage Mapper
            CreateMap<homePageAddDto, HomePage>()
           .ForMember(dest => dest.logoImage, opt => opt.MapFrom(src =>
          uploadImage(src.Logo)));
        }
        public  async Task<string> uploadImage(IFormFile image)//, Guid imageId)
        {
            //return ImageGuid.ToString() + "_" + image.FileName;
            string NewName = Guid.NewGuid().ToString() + image.FileName;
            FileStream fs = new FileStream(
               Path.Combine(Directory.GetCurrentDirectory(),
                "Content", "Images", NewName)
               , FileMode.OpenOrCreate, FileAccess.ReadWrite);
                  image.CopyTo(fs);
               // fs.Close();
                fs.Position = 0;
            return NewName;

        }

        //static string MapBg(IFormFile bg)
        //{
        //   /// return "";
        //    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "ProductsImages");
        //    string imageName = imageId.ToString() + "_" + image.FileName;
        //    string filePath = Path.Combine(uploadFolder, imageName);
        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await image.CopyToAsync(fileStream);
        //        fileStream.Close();
        //    }
        //}
    }
}

    //    CreateMap<ApplicationUser, RegisterDto>()
    //     .ForMember(dest => dest.image, opt => opt.Ignore());
    //    CreateMap<RegisterDto, ApplicationUser>()
    //        .ForMember(dest => dest.image, opt => opt.MapFrom(src => {
    //            if (src.image != null)
    //            {
    //                using var memoryStream = new MemoryStream();
    //                src.image.CopyTo(memoryStream);
    //                return memoryStream.ToArray();
    //            }
    //            return null;
    //        }));


            //CreateMap<RegisterDto, ApplicationUser>()
            //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))       
            //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

           
        //}
    
    

