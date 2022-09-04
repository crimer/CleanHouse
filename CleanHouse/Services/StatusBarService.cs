using Android.Graphics;
using Android.OS;
using CleanHouse.Application.Services;
using Plugin.CurrentActivity;

namespace CleanHouse.Services
{
    public class StatusBarService : IStatusBarService
    {
        public void SetStatusBarColor(string color)
        {
            if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                CrossCurrentActivity.Current.Activity.Window?.SetStatusBarColor(Color.ParseColor(color));
        }
    }
}