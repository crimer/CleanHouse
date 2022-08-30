using System;

namespace CleanHouse.Application.DialogConfigs
{
    public class SnackbarConfig
    {
        public enum SnackbarType
        {
            Error, Warning, Info, Success
        }

        public SnackbarType Type { get; }
        public string Message { get; }
        public Action Action { get; }
        public string ActionText { get; }
        public int Duration { get; }
        
        public  SnackbarConfig(SnackbarType type, string message, string actionText = "", Action action = null)
        {
            Duration = 2000;
            Type = type;
            Action = action;
            Message = message;
            ActionText = actionText;
        }
    }
}