using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Servicio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codServicio");
            builder.Property(p => p.Description).HasColumnName("Descr").IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.State).HasColumnName("Estado");
            builder.Property(p => p.HourValue).HasColumnName("ValorHora").HasColumnType("decimal(12,2)");
            builder.Property(p => p.EndDate).HasColumnName("FechaBaja").HasColumnType("datetime");
        }
    }
}
