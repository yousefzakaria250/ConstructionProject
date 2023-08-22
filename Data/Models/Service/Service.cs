using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Service
{
    [Table("Services")]
    public class Service :EntityBase
    {
        public string title { set; get; } = String.Empty;
        public string titleAR { set; get; } = String.Empty;
        [ForeignKey("ServicePage")]
        public int ServicePageId { set; get;  }
        [JsonIgnore]
        public ServicePage ServicePage { get; set; } = null!;
        public ICollection<ServiceItem> serviceItems { set; get; } = null!;
    }
}
