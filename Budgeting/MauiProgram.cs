using Budgeting.Contracts.Services;
using Budgeting.Services;
using Budgeting.Shells;
using Budgeting.ViewModels;
using Budgeting.ViewModels.Auth;
using Budgeting.ViewModels.Popups;
using Budgeting.ViewModels.Shells;
using Budgeting.Views;
using Budgeting.Views.Popups;
using CommunityToolkit.Maui;
using Microcharts.Maui;
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
                .UseMauiCommunityToolkit()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Shells and ViewModels
            builder.Services.AddTransient<AuthorizedAppShell>();
            builder.Services.AddTransient<AuthorizedAppShellViewModel>();
            builder.Services.AddTransient<UnauthorizedAppShell>();
            builder.Services.AddTransient<UnauthorizedAppShellViewModel>();

            // Pages and ViewModels
            builder.Services.AddSingleton<SplashLoadPage>();
            builder.Services.AddSingleton<SplashLoadPageViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterPageViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<TransactionDetailPage>();
            builder.Services.AddSingleton<TransactionDetailPageViewModel>();

            // Popups and ViewModels
            builder.Services.AddTransientPopup<AddTransactionPopup, AddTransactionPopupViewModel>();
            //builder.Services.AddTransient<AddTransactionPopup>();
            //builder.Services.AddTransient<AddTransactionPopupViewModel>();

            // Services
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<Config.Config>();
            builder.Services.AddSingleton<IAuthService, AuthService>();

            return builder.Build();
        }
    }
}
