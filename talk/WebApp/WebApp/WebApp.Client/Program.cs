using Blazor.Shared.Security;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddSingleton<IBlazorTestService, BlazorClientTestService>();
builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();

await builder.Build().RunAsync();
