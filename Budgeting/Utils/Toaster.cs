using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Budgeting.Utils
{
    public static class Toaster
    {
        public static async Task DisplayShortToastAsync(string message, CancellationToken cancellationToken = default)
        {
            await DisplayToastAsync(message: message, duration: ToastDuration.Short, cancellationToken);
        }

        public static async Task DisplayLongToastAsync(string message, CancellationToken cancellationToken = default)
        {
            await DisplayToastAsync(message: message, duration: ToastDuration.Long, cancellationToken);
        }

        private static async Task DisplayToastAsync(string message, ToastDuration duration, CancellationToken cancellationToken = default)
        {
            var toast = Toast.Make(message: message, duration: duration);
            await toast.Show(cancellationToken);
        }
    }
}
