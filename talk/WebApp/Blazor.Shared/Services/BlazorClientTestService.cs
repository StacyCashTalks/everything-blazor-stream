namespace Blazor.Shared.Services;

public class BlazorClientTestService : IBlazorTestService
{
    public string GetMessage()
    {
        return "Hello from BlazorClientTestService!";
    }
}
