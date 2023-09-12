using Microsoft.EntityFrameworkCore;

namespace TpIntegradorSofttek.DataAcces.Seeds
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
