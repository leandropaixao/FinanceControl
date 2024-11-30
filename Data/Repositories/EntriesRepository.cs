using FinanceControl.Models;

namespace FinanceControl.Data.Repositories;

public class EntriesRepository : IRepository<Entry>
{
    private static readonly List<Entry> _entries = [];

    public static bool RemoveEntry(Guid id)
    {
        var posting = _entries.FirstOrDefault(x => x.Id == id);
        if (posting != null)
        {
            _entries.Remove(posting);
            return true;
        }
        return false;
    }

    public void New(Entry entity)
    {
        _entries.Add(entity);
    }

    public void Edit(Entry entity)
    {
        var postingEdit = _entries.FirstOrDefault(x => x.Id == entity.Id);

        if (postingEdit != null)
        {
            postingEdit = entity;
            postingEdit.ModificationDate = DateTime.Now;
        }
    }

    public bool Remove(Guid id)
    {
        var entry = _entries.FirstOrDefault(x => x.Id == id);
        if (entry != null)
        {
            return _entries.Remove(entry);
        }
        return false;
    }

    public List<Entry> SearchAll()
    {
        return _entries;
    }

    public Entry? SearchById(Guid id)
    {
        return _entries.FirstOrDefault(x => x.Id == id);
    }
}