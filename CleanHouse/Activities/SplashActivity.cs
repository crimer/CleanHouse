using Android.App;
using Android.Content;
using Android.OS;

namespace CleanHouse.Activities
{
    [Activity(
        Theme = "@style/AppTheme.Splash", 
        Label = "@string/app_name", 
        Icon = "@mipmap/ic_squircle_app_launch_icon", 
        RoundIcon="@mipmap/ic_circle_app_launch_icon",
        MainLauncher = true, 
        NoHistory = true)]
    public class SplashActivity : BaseActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistantState)
        {
            base.OnCreate(savedInstanceState, persistantState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Android.App.Application.Context, typeof(LoginActivity)));
        }
    }
}