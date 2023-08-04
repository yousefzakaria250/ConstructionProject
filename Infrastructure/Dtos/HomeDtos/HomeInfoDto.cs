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
        public int Id { get; set; }
        public string logoImage { get; set; }
        public ICollection<SliderInfoDto> sliders { get; set; }
        public AboutPageDto about { get; set; }
        public counterUpInfoDto counterUp { get; set; }
        public Service services { get; set; }
        public ProjectInfoDto project { get; set; }

    }
}
