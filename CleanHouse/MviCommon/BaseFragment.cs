using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using CleanHouse.Application;
using CleanHouse.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanHouse.MviCommon
{
    public abstract class BaseFragment : Fragment
    {
        protected abstract int LayoutViewId { get; }
        public bool IsOverrideBackPressed { get; set; }

        public virtual void OnBackPressed() {}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
            => inflater.Inflate(LayoutViewId, container, false);
    }
    
    public abstract class BaseFragment<TPresenter> : BaseFragment where TPresenter : BasePresenter
    {
        protected TPresenter Presenter { get; }
        protected IDialogService DialogService { get; }
        protected ILogger<BaseFragment<TPresenter>> Logger { get; }

        protected BaseFragment()
        {
            DialogService = AppDependencies.ServiceProvider.GetRequiredService<IDialogService>();
            Logger = AppDependencies.ServiceProvider.GetRequiredService<ILogger<BaseFragment<TPresenter>>>();
            Presenter = AppDependencies.ServiceProvider.GetRequiredService<TPresenter>();
        }
    }
}