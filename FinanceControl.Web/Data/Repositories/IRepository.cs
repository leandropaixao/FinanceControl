namespace FinanceControl.Web.Data.Repositories
{
    public interface IRepository<T>
    {
        Task NewAsync(T entity);
        Task EditAsync(T entity);
        Task<bool> RemoveAsync(Guid id);
        Task<List<T>> SearchAllAsync();
        Task<T?> SearchByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
