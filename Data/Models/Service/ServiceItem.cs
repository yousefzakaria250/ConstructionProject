using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models.Service
{
    public class ServiceItem:EntityBase
    {
        public string title { set; get; } = String.Empty;
        public string titleAR { set; get; } = String.Empty;
        public string desc { set; get; } = String.Empty;
        public string descAR { set; get; } = String.Empty;
        public  string icon { set; get; } = String.Empty;
        [ForeignKey("Service")]
        public int ServiceId { set; get;  }
        [JsonIgnore]
        public Service Service { set; get; } = null!;
    }
}
