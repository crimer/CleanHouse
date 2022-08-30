using System;
using System.Threading.Tasks;
using Android.App;
using Android.Runtime;
using CleanHouse.Application.Helpers;
using CleanHouse.Application.Services;
using CleanHouse.Presenters.Login;
using CleanHouse.Presenters.Main;
using CleanHouse.Services.Impls;
using CleanHouse.Services.Impls.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using CleanHouse.Services.Impls.BClassic;
// using CleanHouse.Services.Impls.BluetoothLE;
// using Plugin.BluetoothClassic.Abstractions;
// using Plugin.BluetoothClassic.Droid;
using Plugin.CurrentActivity;
using Utils = CleanHouse.Helpers.Utils;

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
            
            services.AddSingleton<LoginPresenter>();
            services.AddSingleton<MainPresenter>();
            services.AddSingleton<Utils>();
            services.AddSingleton<FetchSave>();
            // services.AddSingleton<BluetoothClassicConnector>();
            // services.AddSingleton<IBluetoothLe, BluetoothLeService>();
            // services.AddSingleton<IBluetoothAdapter, BluetoothAdapter>();
            // services.AddSingleton<IBluetoothClassic, BluetoothClassicService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IStatusBarService, StatusBarService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<ICurrentActivity>(_ => CrossCurrentActivity.Current);
            services.AddLogging(c =>
            {
                c.ClearProviders();
                c.AddDebug();
            });
            
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