using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionItemsDto
{
    public class SolutionItemsAddDto
    {
        public IFormFile image { get; set; }
        public string ENdesc { get; set; }
        public string ARdesc { get; set; }
        public string ENtitle { get; set; }
        public string ARtitle { get; set; }
        public int SolutionId { get; set; }
    }
}
