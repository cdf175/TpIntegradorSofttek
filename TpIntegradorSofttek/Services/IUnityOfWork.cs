using TpIntegradorSofttek.Repositories;

namespace TpIntegradorSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UsuarioRepository UsuarioRepository { get; }
        Task<int> Complete();

    }
}
