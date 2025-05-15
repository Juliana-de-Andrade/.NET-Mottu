namespace challenger.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAssync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        void Delete(T entity);
    }
}
