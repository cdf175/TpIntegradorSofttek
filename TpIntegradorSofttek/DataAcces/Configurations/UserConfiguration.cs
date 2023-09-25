using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TpIntegradorSofttek.Models;

namespace TpIntegradorSofttek.DataAcces.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("codUsuario");
            builder.Property(p => p.Name).HasColumnName("Nombre").IsRequired().HasColumnType("varchar").HasMaxLength(200);
            builder.Property(p => p.Dni).IsRequired();
            builder.Property(p => p.Type).HasColumnName("Tipo");
            builder.Property(p => p.Password).HasColumnName("Contrasena").HasColumnType("varchar").HasMaxLength(250);
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.EndDate).HasColumnName("FechaBaja").HasColumnType("datetime");
        }
    }
}
