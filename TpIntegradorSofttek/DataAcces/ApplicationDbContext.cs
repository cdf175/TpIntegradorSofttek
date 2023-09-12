using System.Data;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces.Configurations;
using TpIntegradorSofttek.DataAcces.Seeds;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DataSet Proyectos { get; set; }
        public DataSet Servicios { get; set; }
        public DataSet Trabajos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuracion con Fluent API
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //seed de tabla usuario
            var usuarioSeeder = new UsuarioSeeder();
            usuarioSeeder.SeedDataBase(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServicioConfiguration());
            var servicioSeeder = new ServicioSeeder();
            servicioSeeder.SeedDataBase(modelBuilder);
           
            modelBuilder.ApplyConfiguration(new ProyectoConfiguration());
            var proyectoSeeder = new ProyectoSeeder();
            proyectoSeeder.SeedDataBase(modelBuilder);

            modelBuilder.ApplyConfiguration(new TrabajoConfiguration());
            var trabajoSeeder = new TrabajoSeeder();
            trabajoSeeder.SeedDataBase(modelBuilder);
   

        }

    }
}
