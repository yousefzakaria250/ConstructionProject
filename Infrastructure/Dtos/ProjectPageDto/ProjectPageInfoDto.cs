using Infrastructure.Dtos.ProjectDto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.ProjectPageDto
{
    public class ProjectPageInfoDto
    {
        public int Id { get; set; }
        public string header { get; set; }
        public string bg { get; set; }
        //public int ProjectId { get; set; }
        [JsonProperty(PropertyName = "projects")]
        public ProjectInfoDto? project { get; set; }
    }
}
