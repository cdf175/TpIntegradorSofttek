using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class TrabajoConfiguration : IEntityTypeConfiguration<Trabajo>
    {
        public void Configure(EntityTypeBuilder<Trabajo> builder)
        {
            builder.ToTable("Trabajo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codTrabajo");
            builder.Property(p => p.ProyectoId).HasColumnName("codProyecto");
            builder.Property(p => p.ServicioId).HasColumnName("codServicio");
            builder.Property(p => p.Fecha).HasColumnType("datetime");
            builder.Property(p => p.CantHoras);
            builder.Property(p => p.ValorHora).HasColumnType("decimal(12,2)");
            builder.Property(p => p.Costo).HasColumnType("decimal(12,2)");
            builder.Property(p => p.FechaBaja).HasColumnType("datetime");
            builder.HasOne(p => p.Proyecto).WithMany(p => p.Trabajos).HasForeignKey(p => p.ProyectoId);
            builder.HasOne(p => p.Servicio).WithMany(p => p.Trabajos).HasForeignKey(p => p.ServicioId);
        }
    }
}
