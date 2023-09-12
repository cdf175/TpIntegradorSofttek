using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("Proyecto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codProyecto");
            builder.Property(p => p.Nombre).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Estado);
            builder.Property(p => p.Direccion).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.FechaBaja).HasColumnType("datetime");
        }
    }
}
