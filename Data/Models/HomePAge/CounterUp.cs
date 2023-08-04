using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.HomePAge
{
    public class CounterUp:EntityBase
    {
        public string BgImage { get; set; }
        public ICollection<Counter> Counter { get; set; }
    }
}
