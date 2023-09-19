using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Helpers;
using TpIntegradorSofttek.Models;
using TpIntegradorSofttek.Repositories.Interfaces;

namespace TpIntegradorSofttek.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context){ }
        public override async Task<List<User>> GetAll()
        {
            return await _context.Set<User>().Where(p => p.EndDate == null).ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            var list = await _context.Set<User>().Where(p => p.EndDate == null && p.Id == id).ToListAsync();
            return list.Count < 1? null: list[0];
        }

        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == updateUser.Id);

            if(user == null) return false;

            user.Name = updateUser.Name;
            user.Email = updateUser.Email;
            user.Dni = updateUser.Dni;
            user.Type = updateUser.Type;
            user.Password = updateUser.Password;

            _context.Update(user);

            return true;
            
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncriptPassword(dto.Password));
        }

        public async Task<bool> EmailExist(string email)
        {
            return _context.Users.Any(p => p.Email == email);
        }
        public async Task<bool> EmailUpdateExist(string email,int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
            return _context.Users.Any(p => p.Email == email && user!.Email != email);
        }

    }
}
