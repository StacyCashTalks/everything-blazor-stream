namespace Blazor.Shared.Services;

public class BlazorServerTestService: IBlazorTestService
{
    public string GetMessage()
    {
        return "Hello from BlazorServerTestService!";
    }
}
