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
        public DbSet<AboutPage> AboutPage { set; get; } = null!;
        public DbSet<Section> Section { set; get; } = null!;
        public DbSet<Service> Services { set; get; } = null!;
        public DbSet<ServicePage> ServicePage {  set; get; } = null!;
        public DbSet<ServiceItem> ServiceItems { set; get; } = null!;
        public DbSet<ContentItem> ContentItem { set; get; } = null!;
        public DbSet<ContentPage> ContentPage { set; get; } = null!;
        public DbSet<Content> Content { set; get; } = null!;
        public DbSet<Contact> Contact { set; get; } = null!;
        public DbSet<ContactInfo> ContactInfo { set; get; } = null!;
        public DbSet<ContactIcons> ContactIcons { set; get; } = null!;
        public DbSet<ApplicationUser> users { get; set; } = null!;
        public DbSet<ProjectPage> ProjectPage { get; set; } = null!;
        public DbSet<ProjectItems> ProjectItems { get; set; } = null!;
        public DbSet<Project> Project { get; set; } = null!;
        public DbSet<solutionPage> SolutionPage { get; set; } = null!;
        public DbSet<solutionItems> solutionItems { get; set; } = null!;
        public DbSet<solution> solution { get; set; } = null!;
        public DbSet<HomePage> homePages { get; set; } = null!;
        public DbSet<Counter> counters { get; set; } = null!;
        public DbSet<CounterUp> counterUps { get; set; } = null!;
        public DbSet<slider> sliders { get; set; } = null!;

        public ConstructionContext(DbContextOptions<ConstructionContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AboutPage>()
                .HasOne(o=>o.Section)
                .WithOne(w=>w.Aboutpage)
                .HasForeignKey<Section>(f=>f.AboutPageId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ServicePage>()
                .HasOne(s => s.Service)
                .WithOne(s => s.ServicePage)
                .HasForeignKey<Service>(s => s.ServicePageId)
                .OnDelete(DeleteBehavior.NoAction
                );
            
            modelBuilder.Entity<ServiceItem>().HasOne(i => i.Service).WithMany(m => m.serviceItems).HasForeignKey(f => f.ServiceId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ContentPage>().HasOne(o => o.Content).WithOne(o => o.ContentPage).HasForeignKey<Content>(f => f.ContentPageId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
