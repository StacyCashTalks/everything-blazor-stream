using Auth0.OidcClient;
using BLazor.Shared.Security;
using BLazor.Shared.Services;
using BlazorMAUI.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace BlazorMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IBlazorTestService, ClientTestService>();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "cashmore-duurkoop.eu.auth0.com",
                ClientId = "4OiBiEcEyPuyThf2Jp9VklNK5L4y6yxl",
                RedirectUri = "blazortalkdemo://callback/",
                PostLogoutRedirectUri = "blazortalkdemo://callback/",
                Scope = "openid profile email"
            }));
            builder.Services.AddSingleton<AuthenticationStateProvider, Auth0StateProvider>();
            builder.Services.AddSingleton<ILoginProvider, LoginProvider>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
