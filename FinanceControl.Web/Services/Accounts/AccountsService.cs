using FinanceControl.Web.Data.Repositories;
using FinanceControl.Web.Models;
using FinanceControl.Web.Services.Users;

namespace FinanceControl.Web.Services.Accounts;

public class AccountsService : IAccountsService<Account>
{
    private readonly IRepository<Account> _repository;

    public AccountsService(IRepository<Account> repository) => _repository = repository;

    public async Task EditAsync(Account entity)
    {
        entity.ModificationDate = DateTime.UtcNow;
        await _repository.EditAsync(entity);
    }

    public async Task NewAsync(Account entity)
    {
        entity.RegisterDate = DateTime.UtcNow;
        await _repository.NewAsync(entity);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        return await _repository.RemoveAsync(id);
    }

    public async Task<List<Account>> SearchAllAsync()
    {
        return await _repository.SearchAllAsync();
    }

    public async Task<Account?> SearchByIdAsync(Guid id)
    {
        return await _repository.SearchByIdAsync(id);
    }
}

