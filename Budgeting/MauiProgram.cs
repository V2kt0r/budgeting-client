using Budgeting.Contracts.Services;
using Budgeting.Services;
using Budgeting.ViewModels;
using Budgeting.Views;
using Microsoft.Extensions.Logging;

namespace Budgeting
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Pages and ViewModels
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<SplashLoadPage>();
            builder.Services.AddSingleton<SplashLoadPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();

            // Services
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<Config.Config>();
            builder.Services.AddSingleton<IAuthService, AuthService>();

            return builder.Build();
        }
    }
}
