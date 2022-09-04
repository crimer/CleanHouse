using System;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using CleanHouse.Application;
using CleanHouse.Application.Services;
using CleanHouse.Services;
using CleanHouse.Services.Global;
using CleanHouse.Services.Global.Drawer;
using CleanHouse.Ui.Globals.Drawer;
using CleanHouse.Ui.Screens.LoginScreen;
using CleanHouse.Ui.Screens.LoginScreen.Presenters;
using CleanHouse.Ui.Screens.MainScreen;
using CleanHouse.Ui.Screens.MainScreen.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Plugin.CurrentActivity;

namespace CleanHouse
{
#if DEBUG
    [Application(Debuggable = true)]
    #else
    [Application(Debuggable = false)]
#endif
    public sealed class MainApplication : Android.App.Application
    {
        public static MainApplication Current { get; private set; }
        
        /// <summary>
        /// Не удалять!!!
        /// </summary>
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Current = this;
        }
        
        private void RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<GlobalDrawerController>();
            services.AddSingleton<GlobalToolbarController>();
            services.AddSingleton<GlobalNavigationController>();
            services.AddSingleton<ScreenFactory>();
            
            // Presenters
            services.AddSingleton<LoginPresenter>();
            services.AddSingleton<MainPresenter>();

            // Screens
            services.AddSingleton<LoginScreen>();
            services.AddSingleton<MainScreen>();
            
            // Fragments
            services.AddSingleton<NavigationDrawerFragment>();

            services.AddSingleton<Utils.Utils>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IStatusBarService, StatusBarService>();
            services.AddSingleton<ICurrentActivity>(_ => CrossCurrentActivity.Current);
            
            services.RegisterApplicationDependencies();
            
            AppDependencies.Build(services);
        }
        
        public override void OnCreate()
        {
            RegisterServices();

            base.OnCreate();
            
            AppConfig.SetUpApplication(this);
            
            AppDomain.CurrentDomain.UnhandledException += AppErrorHandler.CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += AppErrorHandler.TaskSchedulerOnUnobservedTaskException;
        }
    }
}