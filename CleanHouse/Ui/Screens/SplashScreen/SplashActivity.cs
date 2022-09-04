using Android.App;
using Android.Content;
using Android.Support.V7.App;

namespace CleanHouse.Ui.Screens.SplashScreen
{
    [Activity(
        Theme = "@style/AppTheme.Splash", 
        Label = "@string/app_name", 
        Icon = "@mipmap/ic_squircle_app_launch_icon", 
        RoundIcon="@mipmap/ic_circle_app_launch_icon",
        MainLauncher = true, 
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Android.App.Application.Context, typeof(AppActivity)));
        }
    }
}