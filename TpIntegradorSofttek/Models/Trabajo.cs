namespace TpIntegradorSofttek.Models
{
    public class Trabajo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProyectoId { get; set; }
        public int ServicioId { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public Decimal Costo { get ; set; }
        public DateTime? FechaBaja { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Servicio Servicio { get; set; }

    }
}
