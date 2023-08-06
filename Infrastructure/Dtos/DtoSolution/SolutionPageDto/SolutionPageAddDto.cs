using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionPageDto
{
    public class SolutionPageAddDto
    {
        public string ENheader { get; set; }
        public string ARheader { get; set; }
        public IFormFile bgImage { get; set; }
    }
}
