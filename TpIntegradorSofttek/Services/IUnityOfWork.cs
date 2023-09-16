using TpIntegradorSofttek.Repositories;

namespace TpIntegradorSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; }
        Task<int> Complete();

    }
}
