using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using CleanHouse.Application;
using CleanHouse.MviCommon;
using CleanHouse.Services.Global;
using CleanHouse.Ui.Globals;
using CleanHouse.Ui.Globals.Drawer;
using CleanHouse.Ui.Screens.LoginScreen;
using Microsoft.Extensions.DependencyInjection;

namespace CleanHouse.Ui
{
    [Activity(Theme = "@style/AppTheme")]
    public class AppActivity : AppCompatActivity
    {
        private BaseFragment CurrentFragment 
            => SupportFragmentManager
                .FindFragmentById(Resource.Id.main_activity_container) as BaseFragment;

        private readonly GlobalNavigationController _globalNavigationController;
        private readonly GlobalToolbarController _globalToolbarController;

        public AppActivity()
        {
            _globalNavigationController = AppDependencies.ServiceProvider.GetRequiredService<GlobalNavigationController>();
            _globalToolbarController = AppDependencies.ServiceProvider.GetRequiredService<GlobalToolbarController>();
        }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _globalNavigationController.Init(this, Resource.Id.main_activity_container);
            _globalToolbarController.Init(this);
            
            _globalNavigationController.SetRootScreen<LoginScreen>();
        }

        public override void OnBackPressed()
        {
            if (CurrentFragment.IsOverrideBackPressed)
                CurrentFragment?.OnBackPressed();
            else
                base.OnBackPressed();
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            if (hasFocus)
                SetWindowLayout();
        }

        private void SetWindowLayout()
        {
            if (Window == null) 
                return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                var wicController = Window.InsetsController;
                Window.SetDecorFitsSystemWindows(false);
                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                if (wicController == null) 
                    return;

                wicController.Hide(WindowInsets.Type.Ime());
                wicController.Hide(WindowInsets.Type.NavigationBars());
            }
            else
            {
#pragma warning disable CS0618
                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)
                    (SystemUiFlags.Fullscreen | SystemUiFlags.HideNavigation |
                     SystemUiFlags.Immersive | SystemUiFlags.ImmersiveSticky |
                     SystemUiFlags.LayoutHideNavigation | SystemUiFlags.LayoutStable | SystemUiFlags.LowProfile);
#pragma warning restore CS0618
            }
        }
    }
}