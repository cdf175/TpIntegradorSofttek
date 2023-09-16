using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.ToTable("Trabajo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codTrabajo");
            builder.Property(p => p.ProyectId).HasColumnName("codProyecto");
            builder.Property(p => p.ServiceId).HasColumnName("codServicio");
            builder.Property(p => p.Date).HasColumnName("Fecha").HasColumnType("datetime");
            builder.Property(p => p.HourQuantity).HasColumnName("CantHoras"); 
            builder.Property(p => p.HourValue).HasColumnName("ValorHora").HasColumnType("decimal(12,2)");
            builder.Property(p => p.Cost).HasColumnName("Costo").HasColumnType("decimal(12,2)");
            builder.Property(p => p.EndDate).HasColumnName("FechaBaja").HasColumnType("datetime");
            builder.HasOne(p => p.Proyect).WithMany(p => p.Works).HasForeignKey(p => p.ProyectId);
            builder.HasOne(p => p.Service).WithMany(p => p.Works).HasForeignKey(p => p.ServiceId);
        }
    }
}
