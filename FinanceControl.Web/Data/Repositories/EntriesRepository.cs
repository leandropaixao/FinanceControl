using FinanceControl.Web.Models;

namespace FinanceControl.Web.Data.Repositories;

public class EntriesRepository : BaseRepository<Entry>
{
    public EntriesRepository(AppDbContext context) : base(context) { }
}