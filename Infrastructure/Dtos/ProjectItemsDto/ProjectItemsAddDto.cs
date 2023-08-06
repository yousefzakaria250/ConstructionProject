using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectItemsDto
{
    public class ProjectItemsAddDto
    {
        public IFormFile image { get; set; }
        public string ENdesc1 { get; set; }
        public string ARdesc1 { get; set; }
        public string ENdesc2 { get; set; }
        public string ARdesc2 { get; set; }
        public string ENtitle { get; set; }
        public string ARtitle { get; set; }
        public int projectID { get; set; }
    }
}
