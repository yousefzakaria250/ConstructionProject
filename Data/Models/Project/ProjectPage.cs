using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Project
{
    public class ProjectPage:EntityBase
    { 
        public string ENheader { get; set; }
        public string ARheader { get; set; }
        public string bg { get; set; }
        //[ForeignKey("project")]
        //public int ProjectId { set; get; }
        public Project project { set; get; }
    }
}
