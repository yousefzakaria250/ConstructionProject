using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos.SliderDto
{
    public class SliderAddDto
    {
        public IFormFile BgImage { get; set; }
        public string ENdesc { get; set; }
        public string ARdesc { get; set; }
        public string ENtitle { get; set; }
        public string ARtitle { get; set; }


    }
}
