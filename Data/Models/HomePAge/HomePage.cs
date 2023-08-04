using Data.Models.About;
using Data.Models.Project;
using Data.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.HomePAge
{
    public class HomePage:EntityBase
    {
        public string ?logoImage { get; set; }
        public CounterUp? counterUp { get; set; }
        public ServicePage? services { get; set; }
        public ProjectPage? project { get; set; }  
        public AboutPage? about { get; set; }
        public ICollection<slider> ?sliders{ get; set; }
       



    }
}
