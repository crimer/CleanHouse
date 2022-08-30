using Android.OS;
using Android.Support.V7.App;
using CleanHouse.Application.Services;
using CleanHouse.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanHouse.Activities
{
    public abstract class BaseActivity :  AppCompatActivity { }
    
    public abstract class BaseActivity<TPresenter> : BaseActivity where TPresenter : BasePresenter
    {
        protected abstract int LayoutViewId { get; }
        protected abstract TPresenter Presenter { get; set; }
        protected IDialogService DialogService { get; }
        protected ILogger<BaseActivity<TPresenter>> Logger { get; }

        public BaseActivity()
        {
            DialogService = Startup.ServiceProvider.GetRequiredService<IDialogService>();
            Logger = Startup.ServiceProvider.GetRequiredService<ILogger<BaseActivity<TPresenter>>>();
        }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(LayoutViewId);
            
            Presenter = Startup.ServiceProvider.GetRequiredService<TPresenter>();
            
            SetUpBindings();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected abstract void SetUpBindings();
        protected abstract void Dispose();
    }
}