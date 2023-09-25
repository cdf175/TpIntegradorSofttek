using System.Net;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Models
{
    public class Service
    {
        public Service()
        {
        }
        public Service(ServiceDto dto)
        {
            Description = dto.Description;
            State = dto.State;
            HourValue = dto.HourValue;
        }
        public Service(ServiceDto dto, int id)
        {
            Id = id;
            Description = dto.Description;
            State = dto.State;
            HourValue = dto.HourValue;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public decimal HourValue { get; set; }
        //campo para baja lógica
        [JsonIgnore]
        public DateTime? EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Work> Works { get; set; }
    }
}
