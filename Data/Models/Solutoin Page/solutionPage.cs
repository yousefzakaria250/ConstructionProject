
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solutionPage:EntityBase
    {
        public string ENheader { get; set; }
        public string ARheader { get; set; }
        public string bgImage { get; set; }
        public solution solution { set; get; }
    }
}
