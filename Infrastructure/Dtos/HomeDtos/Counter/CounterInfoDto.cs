using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos.Counter
{
    public class CounterInfoDto
    {
        public int Id { get; set; }
        public string icon { get; set; }
        public int count { get; set; }
        public string desc { get; set; }
    }
}
