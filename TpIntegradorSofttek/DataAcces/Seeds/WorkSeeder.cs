using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class WorkSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Work> trabajosInit = new List<Work>();
            trabajosInit.Add(new Work { Id = 1, ProyectId = 1, ServiceId = 1, HourQuantity = 700, HourValue = 70000, Date = DateTime.Now, Cost = 700 * 70000 });
            trabajosInit.Add(new Work { Id = 2, ProyectId = 2, ServiceId = 1, HourQuantity = 820, HourValue = 71000, Date = DateTime.Now, Cost = 820 * 71000 });

            modelBuilder.Entity<Work>().HasData(trabajosInit);
        }
    }
}
