using Data.Models.About;
using Data.Models.Contact;
using Data.Models.Content;
using Data.Models.HomePAge;
using Data.Models.Project;
using Data.Models.Service;
using Data.Models.Solutoin_Page;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Construction_Context
{
    public class ConstructionContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<AboutPage> AboutPage { set; get; }
        public DbSet<Section> Section { set; get; }
        public DbSet<Service> Services { set; get;  }
        public DbSet<ServicePage> ServicePage {  set; get; }    
        public DbSet<ServiceItem> ServiceItems { set; get; }
        public DbSet<ContentItem> ContentItem { set; get; }
        public DbSet<ContentPage> ContentPage { set; get; }
        public DbSet<Content> Content { set; get; }

        public DbSet<Contact> Contact { set; get; }
        public DbSet<ContactInfo> ContactInfo { set; get; }
        public DbSet<ContactIcons> ContactIcons { set; get; }



        //by MH
        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<ProjectPage> ProjectPage { get; set; }

        public DbSet<ProjectItems> ProjectItems { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<solutionPage> SolutionPage { get; set; }

        public DbSet<solutionItems> solutionItems { get; set; }
        public DbSet<solution> solution { get; set; }

        //Home Page
        public DbSet<HomePage> homePages { get; set; }
        public DbSet<Counter> counters { get; set; }
        public DbSet<CounterUp> counterUps { get; set; }
        public DbSet<slider> sliders { get; set; }

        public ConstructionContext(DbContextOptions<ConstructionContext> options) :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AboutPage>().HasOne(o=>o.Section).WithOne(w=>w.Aboutpage).HasForeignKey<Section>(f=>f.AboutPageId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ServicePage>().HasOne(s => s.Service).WithOne(s => s.ServicePage).HasForeignKey<Service>(s => s.ServicePageId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ServiceItem>().HasOne(i => i.Service).WithMany(m => m.serviceItems).HasForeignKey(f => f.ServiceId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ContentPage>().HasOne(o => o.Content).WithOne(o => o.ContentPage).HasForeignKey<Content>(f => f.ContentPageId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
