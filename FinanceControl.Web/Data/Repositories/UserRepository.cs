using FinanceControl.Web.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceControl.Web.Data.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        const string GUEST = "Guest";
        readonly AppDbContext _context;
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null )
            {
                return false;
            }
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result != PasswordVerificationResult.Success)
            {
                return false;
            }

            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        }, "customAuth");

            _currentUser = new ClaimsPrincipal(identity);
            return true;
        }

        public void Logout()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        }

        public Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public string GetNameCurrentUser() => _currentUser.Identity?.Name ?? GUEST;
        public async Task<User?> GetCurrentUser() => await _context.Users.FirstOrDefaultAsync(u => u.Username == GetNameCurrentUser());
    }
}
