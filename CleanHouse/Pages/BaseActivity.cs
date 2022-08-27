using Android.OS;
using Android.Support.V7.App;
using CleanHouse.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CleanHouse.Pages
{
    public abstract class BaseActivity :  AppCompatActivity { }
    
    public abstract class BaseActivity<TVm> : BaseActivity where TVm : BaseVm
    {
        protected abstract int LayoutViewId { get; }
        protected abstract TVm ViewModel { get; set; }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(LayoutViewId);
            
            ViewModel = Startup.ServiceProvider.GetRequiredService<TVm>();
            
            SetUpBindings();
        }

        protected abstract void SetUpBindings();
        protected abstract void Dispose();
    }
}