using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.HomePAge
{
    public class slider:EntityBase
    {
        public string BgImage { get; set; } = String.Empty;
        public string ENTitle { get; set; } = String.Empty;
        public string ARTitle { get; set; } = String.Empty;
        public string ARdesc { get; set; } = String.Empty;
        public string ENdesc { get; set; } = String.Empty;

    }
}
