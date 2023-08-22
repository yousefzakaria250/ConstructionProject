using Infrastructure.Dtos.HomeDtos.SliderDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos
{
    public class ServiceInfoDto
    {
        //public int Id { get; set; }
        public string header { set; get; }
       
        //public string bg { set; get; }
        //public string title { set; get; }
       // public List<ServiceItemDto>section1 { set; get; }
        public List<HomeServiceSectionDto>section { set; get; }
    }
}
