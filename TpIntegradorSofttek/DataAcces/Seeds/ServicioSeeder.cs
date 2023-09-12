using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Servicio> serviciosInit = new List<Servicio>();
            serviciosInit.Add(new Servicio {Id = 1, Descr = "Construccion torre petrolera", Estado = true, ValorHora = 40000 });
            serviciosInit.Add(new Servicio {Id = 2, Descr = "Refinamiento petroleo", Estado = true, ValorHora = 25000 });

            modelBuilder.Entity<Servicio>().HasData(serviciosInit);
        }
    }
}
