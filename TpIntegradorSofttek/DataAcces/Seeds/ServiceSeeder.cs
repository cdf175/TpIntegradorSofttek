using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Service> serviciosInit = new List<Service>();
            serviciosInit.Add(new Service {Id = 1, Description = "Construccion torre petrolera", State = true, HourValue = 40000 });
            serviciosInit.Add(new Service {Id = 2, Description = "Refinamiento petroleo", State = true, HourValue = 25000 });

            modelBuilder.Entity<Service>().HasData(serviciosInit);
        }
    }
}
