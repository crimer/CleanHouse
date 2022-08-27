using System;
using System.IO;
using System.Threading.Tasks;

namespace CleanHouse
{
    public static class AppErrorHandler
    {
        internal static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new Exception(
                "Task Scheduler On Unobserved Task Exception", 
                unobservedTaskExceptionEventArgs.Exception);
            
            LogUnhandledException(newExc);
        }

        internal static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception(
                "Current Domain On Unhandled Exception", 
                unhandledExceptionEventArgs.ExceptionObject as Exception);
            
            LogUnhandledException(newExc);
        }

        private static void LogUnhandledException(Exception exception)
        {
            try
            {
                const string errorFileName = "Fatal.log";
                var libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                
                var errorFilePath = Path.Combine(libraryPath, errorFileName);
                var errorMessage = $"Time: {DateTime.Now}\r\nError: Unhandled Exception\r\n{exception}";
                
                File.WriteAllText(errorFilePath, errorMessage);

                Android.Util.Log.Error("Crash Report", errorMessage);
            }
            catch { /* ignored */ }
        }
    }
}