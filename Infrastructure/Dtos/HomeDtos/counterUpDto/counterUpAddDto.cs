using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos.counterUpDto
{
    public class counterUpAddDto
    {
       
        public IFormFile BgImage { get; set; }
       // public ICollection<Counter> Counter { get; set; }
    }
}
