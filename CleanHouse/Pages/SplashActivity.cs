using Android.App;
using Android.Content;
using Android.OS;

namespace CleanHouse.Pages
{
    [Activity(
        Theme = "@style/AppTheme.Splash", 
        MainLauncher = true, 
        NoHistory = true, 
        Label = "Clean House")]
    public class SplashActivity : BaseActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistantState)
        {
            base.OnCreate(savedInstanceState, persistantState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Android.App.Application.Context, typeof(MainActivity)));
        }
    }
}