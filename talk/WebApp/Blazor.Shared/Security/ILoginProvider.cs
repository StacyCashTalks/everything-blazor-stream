namespace Blazor.Shared.Security;

public interface ILoginProvider
{
    Task LoginAsync();
    Task LogoutAsync();
}
