using System.Text.Json.Serialization;

namespace TpIntegradorSofttek.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }
        public DateTime? FechaBaja { get; set; }

        [JsonIgnore]
        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
