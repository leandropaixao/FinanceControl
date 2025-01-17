using FinanceControl.Web.Data.Repositories;
using FinanceControl.Web.Models;

namespace FinanceControl.Web.Services.Entries;

public interface IEntriesOperations
{
    Task ConfirmTransaction(Entry entry);
}

public class EntriesService : IEntriesService<Entry>, IEntriesOperations 
{
    private readonly IRepository<Entry> _repository;
    
    public EntriesService(IRepository<Entry> repository) => _repository = repository;
    public async Task NewAsync(Entry entity)
    {
        entity.RegisterDate = DateTime.UtcNow;
        await _repository.NewAsync(entity);
    }

    public async Task EditAsync(Entry entity)
    {
        entity.ModificationDate = DateTime.UtcNow;
        await _repository.EditAsync(entity);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _repository.RemoveAsync(id);
    }

    public async Task<List<Entry>> SearchAllAsync()
    {
        return await _repository.SearchAllAsync();
    }

    public async Task<Entry?> SearchByIdAsync(Guid id)
    {
        return await _repository.SearchByIdAsync(id);
    }

    public async Task ConfirmTransaction(Entry entry)
    {
        var totalPaid = entry.Amount - entry.Discount + entry.Interest;
        
        entry.TotalTransactions = totalPaid;
        if (entry.Account != null)
        {
            entry.Account.UpdateBalance(entry.Type == EntryType.Credit ? totalPaid : totalPaid *-1);
            entry.Account.Movimented = true;
        }
        entry.ExecutedTransaction = true;
        entry.PaymentDate = DateTime.UtcNow;
        entry.ModificationDate = DateTime.UtcNow;
        await _repository.EditAsync(entry);
    }
}