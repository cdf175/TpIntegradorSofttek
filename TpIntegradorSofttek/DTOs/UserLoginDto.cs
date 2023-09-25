using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class UserLoginDto
    {
        public string Name { get; set; }
        public int Dni { get; set; }
        public Roles Type { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
