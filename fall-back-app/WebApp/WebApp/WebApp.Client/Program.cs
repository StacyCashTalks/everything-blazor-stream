using BLazor.Shared.Security;
using BLazor.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();
builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<ILoginProvider, WebLoginProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
