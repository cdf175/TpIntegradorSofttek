using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dni { get; set; }
        public Roles Type { get; set; }
        public string Email { get; set; }
    }
}
