using BLazor.Shared.Security;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorMAUI.Security;

public class LoginProvider : ILoginProvider
{
    private readonly Auth0StateProvider _auth0StateProvider;

    public LoginProvider(AuthenticationStateProvider stateProvider)
    {
        if (stateProvider is Auth0StateProvider auth0StateProvider)
        {
            _auth0StateProvider = auth0StateProvider;
        }
        else
        {
            throw new ArgumentException(nameof(stateProvider));
        }
    }

    public async Task LoginAsync()
    {
        await _auth0StateProvider.LoginAsync();
    }

    public async Task LogoutAsync()
    {
        await _auth0StateProvider.LogoutAsync();
    }
}