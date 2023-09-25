namespace TpIntegradorSofttek.DTOs
{
    public class WorkDto
    {
        public DateTime Date { get; set; }
        public int ProyectId { get; set; }
        public int ServiceId { get; set; }
        public int HourQuantity { get; set; }
        public decimal HourValue { get; set; }
    }
}
