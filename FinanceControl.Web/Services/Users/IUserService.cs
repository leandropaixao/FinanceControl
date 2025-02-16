using FinanceControl.Web.Data.Repositories;
using FinanceControl.Web.Models;

namespace FinanceControl.Web.Services.Users
{
    public interface IUserService<T> : IService<T> where T : class
    {
        string GetNameCurrentUser();
        Task<User?> GetCurrentUser();
    }
}
