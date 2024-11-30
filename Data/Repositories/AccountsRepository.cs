using FinanceControl.Models;
using Microsoft.Win32;
using System.Security.Principal;

namespace FinanceControl.Data.Repositories;

public class AccountsRepository : IRepository<Account>
{
    private static readonly List<Account> _accounts = [];

    public void New(Account entity)
    {
        _accounts.Add(entity);
    }

    public void Edit(Account registry)
    {
        var accountEdit = _accounts.FirstOrDefault(x => x.Id == registry.Id);
        if (accountEdit != null)
        {
            accountEdit.Active = registry.Active;
            accountEdit.Description = registry.Description;
            accountEdit.InitialBalance = registry.InitialBalance;
            accountEdit.ModificationDate = DateTime.Now;
        }
    }

    public bool Remove(Guid id)
    {
        var account = _accounts.FirstOrDefault(x => x.Id == id);
        if (account != null)
        {
            _accounts.Remove(account);
            return true;
        }
        return false;
    }

    public List<Account> SearchAll()
    {
        return _accounts;
    }

    public Account? SearchById(Guid id)
    {
        return _accounts.FirstOrDefault(x => x.Id == id);
    }
}
