using System.Text.Json.Serialization;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;

namespace TpIntegradorSofttek.Models
{
    public class User
    {
        public User()
        {

        }
        public User(RegisterDto dto)
        {
            Name = dto.Name;
            Dni = dto.Dni;
            Type = dto.Type;
            Email = dto.Email;
            Password = PasswordEncryptHelper.EncriptPassword(dto.Password);

        }
        public User(RegisterDto dto, int id)
        {
            Id = id;
            Name = dto.Name;
            Dni = dto.Dni;
            Type = dto.Type;
            Email = dto.Email;
            Password = PasswordEncryptHelper.EncriptPassword(dto.Password);

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public  int Dni { get; set; }
        public Roles Type { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        //campo para baja lógica
        [JsonIgnore]
        public DateTime? EndDate { get; set; }

    }

    public enum Roles
    {
        Administrator = 1,
        Consultant
    }
}
