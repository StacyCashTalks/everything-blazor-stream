namespace WebApp.Client;
using Blazor.Shared.Security;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

public class WebLoginProvider : ILoginProvider
{
    private readonly NavigationManager navMan;

    public WebLoginProvider(NavigationManager navMan)
    {
        this.navMan = navMan;
    }

    public Task LoginAsync()
    {
        navMan.NavigateTo("Account/Login?returnUrl=/", true);
        return Task.CompletedTask;
    }

    public Task LogoutAsync()
    {
        navMan.NavigateTo("authentication/logout", true);
        return Task.CompletedTask;
    }
}