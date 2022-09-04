using Android.Content;
using Android.Util;
using Android.Views;
using Plugin.CurrentActivity;

namespace CleanHouse.Utils
{
    internal class Utils
    {
        private readonly ICurrentActivity _currentActivity;

        public Utils(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;
        }
        
        /// <summary>
        /// Пщлучение размеров в процентах 
        /// </summary>
        /// <param name="percentagesWidth">Процент по ширине</param>
        /// <param name="percentagesHeight">Процент по высоте</param>
        /// <returns>Кортеж процентов размеров</returns>
        public (double width, double height) GetDevicePercentagesSize(int percentagesWidth, int percentagesHeight)
        {
            var metrics = new DisplayMetrics();
            var windowManager = _currentActivity.Activity.GetSystemService(Context.WindowService) as IWindowManager;
            windowManager.DefaultDisplay.GetMetrics(metrics);

            var appHeight = metrics.HeightPixels;
            var appWidth = metrics.WidthPixels;

            var width = (appHeight * percentagesWidth) / 100;
            var height = (appWidth * percentagesHeight) / 100;
            return (width, height);
        }
    }
}