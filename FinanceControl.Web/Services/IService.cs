namespace FinanceControl.Web.Services;

public interface IService<T>
{
    Task NewAsync(T entity);
    Task EditAsync(T entity);
    Task<bool> RemoveAsync(Guid id);
    Task<List<T>> SearchAllAsync();
    Task<T?> SearchByIdAsync(Guid id);
}

