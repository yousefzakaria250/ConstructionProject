using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos.DtoSolution.SolutionDto
{
    public class SolutionAddDto
    {
        public string ENheader { get; set; }
        public string ARheader { get; set; }

        public string ENtitle { get; set; }
        public string ARtitle { get; set; }

        public int SolutionPageId { get; set; }
    }
}
