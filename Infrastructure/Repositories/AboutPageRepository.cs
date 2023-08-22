using Data.Models.About;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AboutPageRepository : IAboutPageRepository
    {
        private readonly ConstructionContext construction_Context;
        public AboutPageRepository(ConstructionContext construction_Context)
        {
            this.construction_Context = construction_Context;
        }
        public async Task<AboutPage> Get(int id)
        {
            var res = await construction_Context.AboutPage.FirstOrDefaultAsync(o => o.Id == id);
            return res;                   
        }
        public async Task<dynamic> GetAll(string Lang)
        {
            if (Lang == "ar")
            {
                var aboutPage =
                    await construction_Context.AboutPage
                    .Include(i => i.Section)
                     .Select(s =>
                            new
                            {
                                Id = s.Id,
                                header = s.headerAR,
                                bg = s.bg,
                                section = new
                                {
                                    Id = s.Section!.Id,
                                    title = s.Section.TitleAR,
                                    desc = s.Section.DescAR,
                                    image = s.Section.image 
                                }
                            })
                      .ToListAsync();
                return aboutPage;
            }
            else
            {
             var res=    await construction_Context.AboutPage
                        .Include(i => i.Section)
                        .Select(s =>
                        new
                        {
                            Id = s.Id,
                            header = s.header,
                            bg = s.bg,
                            section = new
                            {
                                Id = s.Section!.Id,
                                title = s.Section.title,
                                desc = s.Section.desc,
                                image = s.Section.image
                            }
                        })
                  .ToListAsync();
                return res;
            }
        }
        public async Task<Section?> GetSection(int id)
        {
            var res = await construction_Context.Section.FirstOrDefaultAsync(s=>s.Id == id);
            return res;
        }
        public async Task<dynamic> Insert(AboutDto dto)
        {
            var aboutPage = new AboutPage
            {
                header = dto.header!,
                headerAR = dto.headerAR,
                bg = ConvertImageToString(dto.bg!)
            };
          await construction_Context.AboutPage.AddAsync(aboutPage);
          construction_Context.SaveChanges();
          return aboutPage;
        }
        public async Task<dynamic> InsertSection(SectionDto SectionDto)
        {
            var Section = new Section
            {
                title = SectionDto.title!,
                TitleAR = SectionDto.TitleAR! ,
                DescAR = SectionDto.DescAR! ,
                desc = SectionDto.desc!,
                image = ConvertImageToString(SectionDto.image!),
                AboutPageId = SectionDto.AboutPageId       
            };
            await construction_Context.AddAsync(Section);
            construction_Context.SaveChanges();
            return Section;

        }
        public async Task<dynamic> Update(int id, AboutDto dto)
        {
            var AboutPage = await Get(id);
            AboutPage.header = dto.header!;
           AboutPage.headerAR = dto.headerAR;
            AboutPage.bg = ConvertImageToString(dto.bg!);
            construction_Context.Entry(AboutPage).State = EntityState.Modified;
            construction_Context.SaveChanges();
            return AboutPage;
        
        }

        public async Task<dynamic> UpdateSection(int id, SectionDto dto)
        {
            var section = await GetSection(id);
            if (section is null)
                return null!;
            section.title = dto.title!;
            section.desc = dto.desc!;
            section.DescAR = dto.DescAR!;
            section.TitleAR = dto.TitleAR!;
            section.image = ConvertImageToString(dto.image!);
            construction_Context.Entry(section).State = EntityState.Modified;
            construction_Context.SaveChanges();
            return section;
        }
        public string ConvertImageToString( IFormFile image)
        {
            IFormFile file = image;
            string NewName = Guid.NewGuid().ToString() + file.FileName;
            FileStream fs = new FileStream(
                 Path.Combine(Directory.GetCurrentDirectory(),
                  "Content", "Images", NewName)
                 , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file.CopyTo(fs);
            fs.Position = 0;
            return NewName;
        }

        public async Task<AboutPage> Delete(int Id)
        {
            var AboutPage = await Get(Id);
            construction_Context.Entry(AboutPage).State = EntityState.Deleted;
            construction_Context.SaveChanges();
            return AboutPage;
        }
    }

   
}
