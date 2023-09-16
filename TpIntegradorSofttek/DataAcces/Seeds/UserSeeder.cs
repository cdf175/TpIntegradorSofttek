using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<User> userInit = new List<User>();
            userInit.Add(new User { Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "123456", Dni = 1111, Type = Roles.Administrator });
            userInit.Add(new User { Id = 2, Name = "Test", Email = "test@gmail.com", Password = "123456", Dni = 2222, Type = Roles.Consultant });

            modelBuilder.Entity<User>().HasData(userInit);
        }
    }
}
