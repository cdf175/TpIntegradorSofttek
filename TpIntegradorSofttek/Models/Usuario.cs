using TpIntegradorSofttek.DTOs;

namespace TpIntegradorSofttek.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(RegisterDto dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Email = dto.Email;
            Clave = dto.Clave;

        }
        

        public int Id { get; set; }
        public string Nombre { get; set; }
        public  int Dni { get; set; }
        public Roles Tipo { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public DateTime? FechaBaja { get; set; }

    }

    public enum Roles
    {
        Administrador = 1,
        Consultor
    }
}
