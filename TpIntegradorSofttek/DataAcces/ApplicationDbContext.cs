using System.Data;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces.Configurations;
using TpIntegradorSofttek.DataAcces.Seeds;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataSet Proyects { get; set; }
        public DataSet Services { get; set; }
        public DataSet Works { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuracion con Fluent API
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //seed de tabla usuario
            var usuarioSeeder = new UserSeeder();
            usuarioSeeder.SeedDataBase(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            var servicioSeeder = new ServiceSeeder();
            servicioSeeder.SeedDataBase(modelBuilder);
           
            modelBuilder.ApplyConfiguration(new ProyectConfiguration());
            var proyectoSeeder = new ProyectSeeder();
            proyectoSeeder.SeedDataBase(modelBuilder);

            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            var trabajoSeeder = new WorkSeeder();
            trabajoSeeder.SeedDataBase(modelBuilder);
   

        }

    }
}
