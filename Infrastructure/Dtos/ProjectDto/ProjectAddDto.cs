using Data.Models.Project;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectDto
{

    public class ProjectAddDto
    {
        public string ENheader { get; set; }
        public string ARheader { get; set; }
 
        public string ENtitle { get; set; }
        public string ARtitle { get; set; }

        public int ProjectPageID { get; set; }
        
    }

}
