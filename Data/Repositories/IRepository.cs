namespace FinanceControl.Data.Repositories
{
    public interface IRepository<T>
    {
        void New(T entity);
        void Edit(T entity);
        bool Remove(Guid id);
        List<T> SearchAll();
        T? SearchById(Guid id);
    }
}
