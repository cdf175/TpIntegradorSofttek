namespace TpIntegradorSofttek.Models
{
    public class Work
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProyectId { get; set; }
        public int ServiceId { get; set; }
        public int HourQuantity { get; set; }
        public decimal HourValue { get; set; }
        public Decimal Cost { get ; set; }
        public DateTime? EndDate { get; set; }
        public virtual Proyect Proyect { get; set; }
        public virtual Service Service { get; set; }

    }
}
