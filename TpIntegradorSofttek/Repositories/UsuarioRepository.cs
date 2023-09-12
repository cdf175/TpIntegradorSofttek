using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context){ }
        public override async Task<List<Usuario>> GetAll()
        {
            return await _context.Set<Usuario>().Where(p => p.FechaBaja == null).ToListAsync();
        }
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == dto.Clave);
        }

    }
}
