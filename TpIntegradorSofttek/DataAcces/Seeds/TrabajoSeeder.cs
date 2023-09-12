using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Trabajo> trabajosInit = new List<Trabajo>();
            trabajosInit.Add(new Trabajo { Id = 1, ProyectoId = 1, ServicioId = 1, CantHoras = 700, ValorHora = 70000, Fecha = DateTime.Now, Costo = 700 * 70000 });
            trabajosInit.Add(new Trabajo { Id = 2, ProyectoId = 2, ServicioId = 1, CantHoras = 820, ValorHora = 71000, Fecha = DateTime.Now, Costo = 820 * 71000 });

            modelBuilder.Entity<Trabajo>().HasData(trabajosInit);
        }
    }
}
