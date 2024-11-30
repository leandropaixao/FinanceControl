using FinanceControl.Data.Repositories;
using FinanceControl.Models;

namespace FinanceControl.Services.Entries;

public class EntriesService : IEntriesService<Entry>
{
    private readonly IRepository<Entry> _repository;
    
    public EntriesService(IRepository<Entry> repository) => _repository = repository;
    public void New(Entry entity)
    {
        entity.RegisterDate = DateTime.Now;
        _repository.New(entity);
    }

    public void Edit(Entry entity)
    {
        entity.ModificationDate = DateTime.Now;
        _repository.Edit(entity);
    }

    public bool Remove(Guid id)
    {
        return _repository.Remove(id);
    }

    public List<Entry> SearchAll()
    {
        return _repository.SearchAll();
    }

    public Entry? SearchById(Guid id)
    {
        return _repository.SearchById(id);
    }
}