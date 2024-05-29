using Auth0.OidcClient;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorMAUI.Security;

internal class Auth0StateProvider : AuthenticationStateProvider
{
    private readonly Auth0Client _auth0Client;
    private static ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public Auth0StateProvider(Auth0Client auth0Client)
    {
        _auth0Client = auth0Client;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(currentUser));
    }

    public Task LoginAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithAuth0Async();
            currentUser = user;

            return new AuthenticationState(currentUser);
        }
    }

    private async Task<ClaimsPrincipal> LoginWithAuth0Async()
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());
        var loginResult = await _auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            authenticatedUser = loginResult.User;
        }
        return authenticatedUser;
    }

    public async Task LogoutAsync()
    {
        await _auth0Client.LogoutAsync();
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(currentUser)));
    }
}
