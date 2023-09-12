using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Usuario> usuariosInit = new List<Usuario>();
            usuariosInit.Add(new Usuario { Id = 1, Nombre = "Admin", Email = "admin@gmail.com", Clave = "123456", Dni = 1111, Tipo = Roles.Administrador });
            usuariosInit.Add(new Usuario { Id = 2, Nombre = "Test", Email = "test@gmail.com", Clave = "123456", Dni = 2222, Tipo = Roles.Consultor });

            modelBuilder.Entity<Usuario>().HasData(usuariosInit);
        }
    }
}
