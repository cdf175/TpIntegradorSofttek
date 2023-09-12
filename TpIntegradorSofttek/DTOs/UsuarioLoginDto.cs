using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class UsuarioLoginDto
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public Roles Tipo { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
