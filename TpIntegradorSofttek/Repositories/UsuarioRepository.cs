using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
