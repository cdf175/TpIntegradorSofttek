using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class WorkResponseDto
    {
        public DateTime Date { get; set; }
        public int HourQuantity { get; set; }
        public decimal HourValue { get; set; }
        public Decimal Cost { get; set; }
        public virtual Proyect Proyect { get; set; }
        public virtual Service Service { get; set; }
        
    }
}
