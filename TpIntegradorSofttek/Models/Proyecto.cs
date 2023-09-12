using System.Text.Json.Serialization;
using System.Threading;

namespace TpIntegradorSofttek.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Direccion { get; set; }
        public EstadoProyecto Estado { get; set; }
        public DateTime? FechaBaja { get; set; }

        [JsonIgnore]
        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }

    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado,
        Terminado
    }
}
