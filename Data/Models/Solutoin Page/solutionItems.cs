using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solutionItems:EntityBase
    {
        public string image { get; set; }
        public string ENdesc { get; set; }
        public string ARdesc { get; set; }
        public string ENtitle { get; set; }
        public string ARtitle { get; set; }
        [ForeignKey("solution")]
        public int SolutionID { set; get; }
        public solution solution { set; get; }
    }
}
