namespace TpIntegradorSofttek.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();

    }
}
