using System.Data;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces.Configurations;
using TpIntegradorSofttek.DataAcces.Seeds;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces
{
    public class ApplicationDbContext:DbContext
    {
        public DataSet Usuarios { get; set; }
        public DataSet Proyectos { get; set; }
        public DataSet Servicios { get; set; }
        public DataSet Trabajos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuracion con Fluent API
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            var usuarioSeeder = new UsuarioSeeder();
            usuarioSeeder.SeedDataBase(modelBuilder);


            //List<Servicio> serviciosInit = new List<Servicio>();
            //serviciosInit.Add(new Servicio { Descr = "Construccion torre petrolera", Estado = true, ValorHora = 40000 });
            //serviciosInit.Add(new Servicio { Descr = "Refinamiento petroleo", Estado = true, ValorHora = 25000 });

            modelBuilder.ApplyConfiguration(new ServicioConfiguration());

            var servicioSeeder = new ServicioSeeder();
            servicioSeeder.SeedDataBase(modelBuilder);
            //var servicio = modelBuilder.Entity<Servicio>();
            //servicio.ToTable("Servicio");
            //servicio.HasKey(p => p.Id);
            //servicio.Property(p => p.Id).HasColumnName("codServicio");
            //servicio.Property(p => p.Descr).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            //servicio.Property(p => p.Estado);
            //servicio.Property(p => p.ValorHora).HasColumnType("decimal(12,2)");
            //servicio.Property(p => p.FechaBaja).HasColumnType("datetime");
            //servicio.HasData(serviciosInit);

            //List<Proyecto> proyectosInit = new List<Proyecto>();

            //proyectosInit.Add(new Proyecto { Nombre = "Puesto Rojas", Direccion = "Malargüe, Mendoza", Estado = EstadoProyecto.Pendiente });
            //proyectosInit.Add(new Proyecto { Nombre = "Bandurria Sur", Direccion = "Cuenca Neuquina Sur", Estado = EstadoProyecto.Confirmado });

            modelBuilder.ApplyConfiguration(new ProyectoConfiguration());

            var proyectoSeeder = new ProyectoSeeder();
            proyectoSeeder.SeedDataBase(modelBuilder);

            //var proyecto = modelBuilder.Entity<Proyecto>();
            //proyecto.ToTable("Proyecto");
            //proyecto.HasKey(p => p.Id);
            //proyecto.Property(p => p.Id).HasColumnName("codProyecto");
            //proyecto.Property(p => p.Nombre).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            //proyecto.Property(p => p.Estado);
            //proyecto.Property(p => p.Direccion).HasColumnType("varchar").HasMaxLength(100);
            //proyecto.Property(p => p.FechaBaja).HasColumnType("datetime");
            //proyecto.HasData(proyectosInit);

            //List<Trabajo> trabajosInit = new List<Trabajo>();
            //trabajosInit.Add(new Trabajo { CodProyecto = 1, CodServicio = 1, CantHoras = 700, ValorHora = 70000, Fecha = DateTime.Now, Costo = 700 * 70000 });
            //trabajosInit.Add(new Trabajo { CodProyecto = 2, CodServicio = 1, CantHoras = 820, ValorHora = 71000, Fecha = DateTime.Now, Costo = 820 * 71000 });

            //var trabajo = modelBuilder.Entity<Trabajo>();
            //trabajo.ToTable("Trabajo");
            //trabajo.HasKey(p => p.Id);
            //trabajo.Property(p => p.Id).HasColumnName("codTrabajo");
            //trabajo.Property(p => p.Fecha).HasColumnType("datetime");
            //trabajo.Property(p => p.CantHoras);
            //trabajo.Property(p => p.ValorHora).HasColumnType("decimal(12,2)");
            //trabajo.Property(p => p.Costo).HasColumnType("decimal(12,2)");
            //trabajo.Property(p => p.FechaBaja).HasColumnType("datetime");
            //trabajo.HasOne(p => p.Proyecto).WithMany(p => p.Trabajos).HasForeignKey(p => p.CodProyecto);
            //trabajo.HasOne(p => p.Servicio).WithMany(p => p.Trabajos).HasForeignKey(p => p.CodServicio);
            modelBuilder.ApplyConfiguration(new TrabajoConfiguration());

            var trabajoSeeder = new TrabajoSeeder();
            trabajoSeeder.SeedDataBase(modelBuilder);
            //trabajo.HasData(trabajosInit);

        }

    }
}
