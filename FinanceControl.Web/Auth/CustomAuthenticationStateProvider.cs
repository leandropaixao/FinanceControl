using FinanceControl.Web.Models;
using FinanceControl.Web.Services.Users;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceControl.Web.Auth;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly UserService _authService;

    public CustomAuthenticationStateProvider(IUserService<User> authService) => _authService = (UserService)authService;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return _authService.GetAuthenticationStateAsync();
    }

    public async Task<bool> Login(string? username, string? password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return false;
        }
        var success = await _authService.Login(username, password);
        NotifyAuthenticationStateChanged(_authService.GetAuthenticationStateAsync());
        return success;
    }

    public void Logout()
    {
        _authService.Logout();
        NotifyAuthenticationStateChanged(_authService.GetAuthenticationStateAsync());
    }
}
