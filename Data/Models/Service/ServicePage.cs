using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    public class ServicePage :EntityBase
    {
        public string header { set; get; } = String.Empty;
        public string headerAR { set; get; } = String.Empty;
        public string bg { set; get; } = String.Empty;
        public Service Service { set; get; } = null!;
    }
}
