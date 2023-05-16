namespace MusicAPIV2.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>?> GetAllAsync();
        Task<T?> GetByIDAsync(int? id);
        Task<List<T>?> DeleteAsync(int? id);
        Task<List<T>?> CreateAsync(T entity);
        Task<List<T>?> UpdateAsync(T entity);
        Task<bool> Exists(int? id);
    }
}
