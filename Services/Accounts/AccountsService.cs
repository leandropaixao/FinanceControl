using FinanceControl.Data.Repositories;
using FinanceControl.Models;

namespace FinanceControl.Services.Accounts
{
    public class AccountsService : IAccountsService<Account>
    {
        private readonly IRepository<Account> _repository;

        public AccountsService(IRepository<Account> repository) => _repository = repository;

        public void Edit(Account entity)
        {
            entity.ModificationDate = DateTime.Now;
            _repository.Edit(entity);
        }

        public void New(Account entity)
        {
            entity.RegisterDate = DateTime.Now;
            _repository.New(entity);
        }

        public bool Remove(Guid id)
        {
            return _repository.Remove(id);
        }

        public List<Account> SearchAll()
        {
            return _repository.SearchAll();
        }

        public Account? SearchById(Guid id)
        {
            return _repository.SearchById(id);
        }
    }
}
