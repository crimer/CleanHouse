using System.Globalization;
using System.Threading;
using Android.Util;
using Plugin.CurrentActivity;

namespace CleanHouse
{
    public static class AppConfig
    {
        public static void SetUpApplication(Android.App.Application application)
        {
            SetLocale(CultureInfo.CreateSpecificCulture("ru-Ru"));
            SetUpLibs(application);
            //InitFontScale(application);
        }

        private static void SetUpLibs(Android.App.Application application)
        {
            CrossCurrentActivity.Current.Init(application);
        }

        private static void InitFontScale(Android.App.Application application)
        {
            var configuration = application.Resources?.Configuration;
            
            if(application?.Display == null || configuration == null)
                return;
            
            configuration.FontScale = 1;
            
            var metrics = new DisplayMetrics();
            // var windowMetrics  = WindowManager.CurrentWindowMetrics;
            //0.85 small, 1 standard, 1.15 big，1.3 more bigger ，1.45 supper big 
            application.Display?.GetMetrics(metrics);
            metrics.ScaledDensity = configuration.FontScale * metrics.Density;
            application.BaseContext?.Resources?.UpdateConfiguration(configuration, metrics);
        }

        private static void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}