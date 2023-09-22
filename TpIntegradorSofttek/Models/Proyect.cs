using System.Net;
using System.Text.Json.Serialization;
using System.Threading;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;

namespace TpIntegradorSofttek.Models
{
    public class Proyect
    {
        public Proyect()
        {
            
        }
        public Proyect(ProyectDto dto)
        {
            Name = dto.Name;
            Address = dto.Address;
            State = dto.State;
        }
        public Proyect(ProyectDto dto,int id)
        {
            Id = id;
            Name = dto.Name;
            Address = dto.Address;
            State = dto.State;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public ProyectState State { get; set; }
        //campo para baja lógica
        [JsonIgnore]
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
