namespace FinanceControl.Services
{
    public interface IService<T>
    {
        void New(T entity);
        void Edit(T entity);
        bool Remove(Guid id);
        List<T> SearchAll();
        T? SearchById(Guid id);
    }
}
