using Infrastructure.Dtos.HomeDtos.Counter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.HomeDtos.counterUpDto
{
    public class counterUpInfoDto
    {
        public int Id { get; set; }
        public string? Bg { get; set; }
        public ICollection<CounterInfoDto>? Counter { get; set; }

    }
}
