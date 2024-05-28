using BLazor.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();

await builder.Build().RunAsync();
