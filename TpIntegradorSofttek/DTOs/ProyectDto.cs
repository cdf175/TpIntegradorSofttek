using System.Text.Json.Serialization;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class ProyectDto
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public ProyectState State { get; set; }

    }
}
