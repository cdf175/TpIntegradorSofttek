using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class ProyectConfiguration : IEntityTypeConfiguration<Proyect>
    {
        public void Configure(EntityTypeBuilder<Proyect> builder)
        {
            builder.ToTable("Proyecto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codProyecto");
            builder.Property(p => p.Name).HasColumnName("Nombre").IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.State).HasColumnName("Estado");
            builder.Property(p => p.Address).HasColumnName("Direccion").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.EndDate).HasColumnName("FechaBaja").HasColumnType("datetime");
        }
    }
}
