using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos.Counter
{
    public class CounterAddDto
    {
        public IFormFile icon { get; set; }
        public int count { get; set; }
        public string ENdesc { get; set; }
        public string ARdesc { get; set; }
        public int counterUpId { get; set; }
    }
}
