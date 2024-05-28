namespace BLazor.Shared.Services;

public class ClientTestService : IBlazorTestService
{
    public string GetTestString() => "Hello from the client!";
}
