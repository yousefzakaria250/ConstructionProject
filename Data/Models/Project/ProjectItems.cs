using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Project
{
    public class ProjectItems:EntityBase
    {
        public string image { get; set; }
        public string ENdesc1 { get; set; }
        public string ARdesc1 { get; set; }

        public string ENtitle { get; set; }
        public string ARtitle { get; set; }
        public string ENdesc2 { get; set; }
        public string ARdesc2 { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { set; get; }
        public Project Project { set; get; }
    }
}
