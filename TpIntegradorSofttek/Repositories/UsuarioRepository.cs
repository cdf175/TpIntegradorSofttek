using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
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

        public override async Task<Usuario> GetById(int id)
        {
            var list = await _context.Set<Usuario>().Where(p => p.FechaBaja == null && p.Id == id).ToListAsync();
            return list.Count < 1? null: list[0];
        }

        public override async Task<bool> Update(Usuario updateUser)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync(p => p.Id == updateUser.Id);

            if(user == null) return false;

            user.Nombre = updateUser.Nombre;
            user.Email = updateUser.Email;
            user.Dni = updateUser.Dni;
            user.Tipo = updateUser.Tipo;
            user.Clave = updateUser.Clave;

            _context.Update(user);

            return true;
            
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == PasswordEncryptHelper.EncriptPassword(dto.Clave));
        }

    }
}
