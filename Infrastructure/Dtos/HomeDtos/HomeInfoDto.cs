using Data.Models.About;
using Data.Models.HomePAge;
using Data.Models.Project;
using Data.Models.Service;
using Infrastructure.Dtos.HomeDtos.counterUpDto;
using Infrastructure.Dtos.HomeDtos.SliderDto;
using Infrastructure.Dtos.ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos
{
    public class HomepageInfoDto
    {
       // public int Id { get; set; }
        public string? logo { get; set; }
        public ICollection<SliderInfoDto>? slider { get; set; }
        public HomeAboutInfoDto? about { get; set; }
        public counterUpInfoDto? counterUp { get; set; }
        public ServiceInfoDto? services { get; set; }
        public ProjectInfoDto? project { get; set; }

    }
}
