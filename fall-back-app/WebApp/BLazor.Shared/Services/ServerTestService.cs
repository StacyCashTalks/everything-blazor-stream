namespace BLazor.Shared.Services;

public class ServerTestService : IBlazorTestService
{
    public string GetTestString() => "Hello from the server!";
}
