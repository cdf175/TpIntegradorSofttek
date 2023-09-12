using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            List<Proyecto> proyectosInit = new List<Proyecto>();

            proyectosInit.Add(new Proyecto { Id = 1, Nombre = "Puesto Rojas", Direccion = "Malargüe, Mendoza", Estado = EstadoProyecto.Pendiente });
            proyectosInit.Add(new Proyecto { Id = 2, Nombre = "Bandurria Sur", Direccion = "Cuenca Neuquina Sur", Estado = EstadoProyecto.Confirmado });

            modelBuilder.Entity<Proyecto>().HasData(proyectosInit);

        }
    }
}
