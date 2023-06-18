namespace WSS.VulnShop.Domain.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetPaginated(int limit, int page);

        Task<int> Insert(T entity);

        Task<int> Update(T entity);

        Task<int> Delete(int id);
    }
}
