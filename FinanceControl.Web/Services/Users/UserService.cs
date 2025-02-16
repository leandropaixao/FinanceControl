using FinanceControl.Web.Data.Repositories;
using FinanceControl.Web.Models;
using FinanceControl.Web.Services.Entries;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinanceControl.Web.Services.Users
{
    public class UserService : IUserService<User>
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository) => _repository = repository;

        public async Task EditAsync(User entity)
        {
            await _repository.EditAsync(entity);
        }

        public async Task NewAsync(User entity)
        {
            var hasher = new PasswordHasher<User>();
            string passwordHash = hasher.HashPassword(entity, entity.PasswordHash);
            entity.PasswordHash = passwordHash;
            await _repository.NewAsync(entity);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<List<User>> SearchAllAsync()
        {
            return await _repository.SearchAllAsync();
        }

        public async Task<User?> SearchByIdAsync(Guid id)
        {
            return await _repository.SearchByIdAsync(id);
        }


        public async Task<bool> Login(string username, string password)
        {  
            return await((UserRepository)_repository).Login(username, password);
        }

        public void Logout()
        {
            ((UserRepository)_repository).Logout();
        }

        public async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await ((UserRepository)_repository).GetAuthenticationStateAsync();
        }

        public string GetNameCurrentUser() => ((UserRepository)_repository).GetNameCurrentUser();
        public async Task<User?> GetCurrentUser() => await ((UserRepository)_repository).GetCurrentUser();
    }
}
