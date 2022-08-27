using System;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using CleanHouse.Application.Services;
using CleanHouse.Services.Impls;
using CleanHouse.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Plugin.CurrentActivity;

namespace CleanHouse
{
#if DEBUG
    [Application(Debuggable = true)]
    #else
    [Application(Debuggable = false)]
#endif
    public class Startup : Android.App.Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Не удалять!!!
        /// </summary>
        protected Startup(System.IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
        
        private void RegisterServices()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<MainVm>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IStatusBarService, StatusBarService>();
            services.AddSingleton<ICurrentActivity>(_ => CrossCurrentActivity.Current);
            
            ServiceProvider = services.BuildServiceProvider();
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