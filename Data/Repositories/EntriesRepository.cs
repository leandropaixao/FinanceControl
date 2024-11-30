using FinanceControl.Models;

namespace FinanceControl.Data.Repositories;

public static class EntriesRepository
{
    public static List<Entry> Entries { get => _entries; }
    static readonly List<Entry> _entries = [];

    public static void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public static void EditEntry(Guid id, Entry entry)
    {
        var postingEdit = _entries.FirstOrDefault(x => x.Id == id);

        if (postingEdit != null)
        {
            postingEdit = entry;
            postingEdit.ChangeDate = DateTime.Now;
        }
    }

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
}