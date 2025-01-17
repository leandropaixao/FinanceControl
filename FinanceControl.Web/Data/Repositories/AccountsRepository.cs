using FinanceControl.Web.Models;

namespace FinanceControl.Web.Data.Repositories;

public class AccountsRepository : BaseRepository<Account>
{
    public AccountsRepository(AppDbContext context) : base(context) { }
}
