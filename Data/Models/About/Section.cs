using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.About
{
    public class Section :EntityBase
    {
        public string title { set; get; } = String.Empty;
        public string TitleAR { set; get; } = String.Empty;
        public string desc { set; get; } = String.Empty;
        public string DescAR { set; get; } = String.Empty;
        public string image { set; get; } = String.Empty;
        [ForeignKey("Aboutpage")]
        public int ?AboutPageId { set; get; }
        [JsonIgnore]
        public AboutPage? Aboutpage { set; get; } = null!;
    }
}
