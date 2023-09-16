using System.Text.Json.Serialization;
using System.Threading;

namespace TpIntegradorSofttek.Models
{
    public class Proyect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public ProyectState State { get; set; }
        public DateTime? EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Work> Works { get; set; }
    }

    public enum ProyectState
    {
        Pending = 1,
        Confirmed,
        Finished
    }
}
