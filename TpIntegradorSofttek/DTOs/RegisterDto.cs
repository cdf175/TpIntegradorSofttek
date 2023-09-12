using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class RegisterDto
    {
        public string Nombre { get; set; }
        public Roles Tipo { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
    }
}
