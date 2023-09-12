using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("Servicio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codServicio");
            builder.Property(p => p.Descr).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Estado);
            builder.Property(p => p.ValorHora).HasColumnType("decimal(12,2)");
            builder.Property(p => p.FechaBaja).HasColumnType("datetime");
        }
    }
}
