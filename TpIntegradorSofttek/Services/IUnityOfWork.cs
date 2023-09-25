using TpIntegradorSofttek.Repositories;

namespace TpIntegradorSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; }
        public ProyectRepository ProyectRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        public WorkRepository WorkRepository { get; }
        Task<int> Complete();

    }
}
