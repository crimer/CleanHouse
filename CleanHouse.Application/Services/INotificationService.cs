using System;

namespace CleanHouse.Application.Services
{
    public interface INotificationService
    {
        event EventHandler NotificationReceived;

        void Initialize();

        int CreateNotification(string title, string message);

        void ReceiveNotification(string title, string message);
    }
}
