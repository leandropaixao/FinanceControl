namespace FinanceControl.Web.Components.Pages.Interfaces;

public interface IListViewBase<T>
{
    public void New();
    public void Edit(Guid id);
    public void Remove(Guid id);
    public void Search();
    public List<T> DataResult();
}