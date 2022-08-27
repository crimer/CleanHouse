using System;
using System.Threading.Tasks;

namespace CleanHouse.Application.Helpers
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
    
    public static class TaskUtilities
    {
        public static async void ExecuteSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}