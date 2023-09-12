using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class UsuarioConfiguration: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codUsuario");
            builder.Property(p => p.Nombre).IsRequired().HasColumnType("varchar").HasMaxLength(200);
            builder.Property(p => p.Dni).IsRequired();
            builder.Property(p => p.Tipo);
            builder.Property(p => p.Clave).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.FechaBaja).HasColumnType("datetime");
        }
    }
}
