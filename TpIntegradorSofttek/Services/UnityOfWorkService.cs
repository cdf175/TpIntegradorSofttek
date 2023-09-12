using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.Repositories;

namespace TpIntegradorSofttek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
