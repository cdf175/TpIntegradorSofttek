using System.Text.Json.Serialization;

namespace TpIntegradorSofttek.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        public DateTime? EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Work> Works { get; set; }
    }
}
