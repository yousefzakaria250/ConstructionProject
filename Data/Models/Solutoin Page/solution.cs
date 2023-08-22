using Data.Models.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Solutoin_Page
{
    public class solution:EntityBase
    {
        public string ENtitle { get; set; } = String.Empty;
        public string ARtitle { get; set; } = String.Empty;
        [ForeignKey("SPage")]
        public int SolutionPageID { get; set; }
        public solutionPage SPage { get; set; } = null!;
        public ICollection<solutionItems> solutions { set; get; } = null!;
    }
}
