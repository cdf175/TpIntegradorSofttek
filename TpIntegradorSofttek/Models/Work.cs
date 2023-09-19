using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Models
{
    public class Work
    {
        public Work()
        {
        }
        public Work(WorkDto dto)
        {
            Date = dto.Date;
            ProyectId = dto.ProyectId;
            ServiceId = dto.ServiceId;
            HourQuantity = dto.HourQuantity;
            HourValue = dto.HourValue;
            Cost = dto.HourQuantity * dto.HourValue;
        }
        public Work(WorkDto dto, int id)
        {
            Id = id;
            Date = dto.Date;
            ProyectId = dto.ProyectId;
            ServiceId = dto.ServiceId;
            HourQuantity = dto.HourQuantity;
            HourValue = dto.HourValue;
            Cost = dto.HourQuantity * dto.HourValue;
        }
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
