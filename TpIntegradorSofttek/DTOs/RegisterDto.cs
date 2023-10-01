using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public Roles Type { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
    }
}
