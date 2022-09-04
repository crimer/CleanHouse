using System;
using Android.App;

namespace CleanHouse.Utils.Extensions
{
    public static class ActivityExtensions
    {
        public static void SafeRunOnUi(this Activity activity, Action action, Action<Exception> onException = null)
            => activity.RunOnUiThread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    onException?.Invoke(ex);
                }
            });
    }
}