using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebApp.Client;

internal class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly Task<AuthenticationState> defaultUnauthenticatedTask =
        Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

    private readonly Task<AuthenticationState> authenticationStateTask = defaultUnauthenticatedTask;

    public PersistentAuthenticationStateProvider(PersistentComponentState state)
    {
        bool foundState = !state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo);
        if (foundState || userInfo is null)
        {
            return;
        }

        List<Claim> claims = new();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, userInfo.UserId));
        claims.Add(new Claim(ClaimTypes.Name, userInfo.Email ?? ""));
        claims.Add(new Claim(ClaimTypes.Email, userInfo.Email ?? ""));

        foreach (var role in userInfo.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        authenticationStateTask = Task.FromResult(
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: nameof(PersistentAuthenticationStateProvider)))));
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationStateTask;
}