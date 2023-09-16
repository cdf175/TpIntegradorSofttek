using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class ProyectSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Proyect> proyectosInit = new List<Proyect>();

            proyectosInit.Add(new Proyect { Id = 1, Name = "Puesto Rojas", Address = "Malargüe, Mendoza", State = ProyectState.Pending });
            proyectosInit.Add(new Proyect { Id = 2, Name = "Bandurria Sur", Address = "Cuenca Neuquina Sur", State = ProyectState.Confirmed });

            modelBuilder.Entity<Proyect>().HasData(proyectosInit);

        }
    }
}
