using TpIntegradorSofttek.DataAcces;
using TpIntegradorSofttek.Repositories;

namespace TpIntegradorSofttek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UserRepository UserRepository { get; private set; }
        public ProyectRepository ProyectRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public WorkRepository WorkRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProyectRepository = new ProyectRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            WorkRepository = new WorkRepository(_context);
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
