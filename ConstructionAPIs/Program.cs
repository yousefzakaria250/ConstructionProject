using Data.Models.HomePAge;
using Data.Models.Project;
using Data.Models.Solutoin_Page;
using Infrastructure.Construction_Context;
using Infrastructure.Dtos.DtoSolution.SolutionDto;
using Infrastructure.Dtos.DtoSolution.SolutionItemsDto;
using Infrastructure.Dtos.DtoSolution.SolutionPageDto;
using Infrastructure.Dtos.HomeDtos.Counter;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Dtos.HomeDtos;
using Infrastructure.Dtos.ProjectDto;
using Infrastructure.Dtos.ProjectItemsDto;
using Infrastructure.Dtos.ProjectPageDto;
using Infrastructure.Repositories;
using Infrastructure.Repositories.HomeRepos;
using Infrastructure.Repositories.ProjectRepo.ProjectRepos;
using Infrastructure.Repositories.SolutionRepos;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using ServiceStack.Text;
using Infrastructure.Mapper;
using Infrastructure.Repositories.ApplicationUserReposatories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var devCorsPolicy = "devCorsPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(devCorsPolicy, builder => {
//        //builder.WithOrigins("http://localhost:800").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
//        //builder.SetIsOriginAllowed(origin => true);
//    });
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//var cors = new EnableCorsAttribute("*");
//Config.Ena(cors);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ConstructionContext>();
builder.Services.AddDbContext<ConstructionContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));
builder.Services.AddScoped<IAboutPageRepository, AboutPageRepository>();
builder.Services.AddScoped<IServicePageRepository, ServicePageRepository>();
builder.Services.AddScoped<IContentPageRepository, ContentPageRepository>();
builder.Services.AddScoped<IContactPageRepository, ContactPageRepository>();

//By Mahmoud Hefny

builder.Services.AddScoped<IPublicInterface<ProjectPageAddDto, ProjectPage, ProjectPageInfoDto>, ProjectPageRepo>();

builder.Services.AddScoped<IPublicInterface<ProjectAddDto, Project, ProjectInfoDto>, ProjectRepo>();
builder.Services.AddScoped<IPublicInterface<ProjectItemsAddDto, ProjectItems, ProjectItemsInfoDto>, ProjectItemsRepo>();

builder.Services.AddScoped<IPublicInterface<SolutionPageAddDto, solutionPage, SolutionPageInfoDto>, SolutionPageRepo>();
builder.Services.AddScoped<IPublicInterface<SolutionAddDto, solution, SolutionInfoDto>, SolutionRepo>();
builder.Services.AddScoped<IPublicInterface<SolutionItemsAddDto, solutionItems, SolutionItemsInfoDto>, SolutionItemsRepo>();

builder.Services.AddScoped<IPublicInterface<CounterAddDto, Counter, CounterInfoDto>, CounterRepo>();
builder.Services.AddScoped<IPublicInterface<counterUpAddDto, CounterUp, counterUpInfoDto>, CounterUpRepo>();
builder.Services.AddScoped<IPublicInterface<SliderAddDto, slider, SliderInfoDto>, SliderRepo>();
builder.Services.AddScoped<IPublicInterface<homePageAddDto, HomePage, HomepageInfoDto>, homePageRepo>();

//Inject AutoMapper
builder.Services.AddAutoMapper(typeof(DomainProfile));
//inject usermager
builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ConstructionContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
         .AddJwtBearer(o =>
         {
             o.RequireHttpsMetadata = false;
             o.SaveToken = true;
             o.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                 ValidAudience = builder.Configuration["JWT:ValidAudiance"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:secret"]))
             };
         });

//builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/Content",
    FileProvider = new PhysicalFileProvider
            (Path.Combine(Directory.GetCurrentDirectory(),
            "Content"))
});

//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
//    RequestPath = new PathString("/Content")
//});




app.UseHttpsRedirection();
app.UseCors("Cors");
app.UseRouting();
//app.UseCors(devCorsPolicy);
app.UseAuthorization();

app.MapControllers();


app.Run();
