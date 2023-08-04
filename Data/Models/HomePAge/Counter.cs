using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.HomePAge
{
    public class Counter:EntityBase
    {
        public string icon { get; set; }
        public int count { get; set; }
        public string desc { get; set; }

        [ForeignKey("counterup")]
        public int counterUpId { set; get; }
        public CounterUp counterup { set; get; }
    }
}
