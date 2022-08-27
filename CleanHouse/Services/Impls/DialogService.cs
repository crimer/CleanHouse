using CleanHouse.Application.DialogConfigs;
using CleanHouse.Application.Services;
using CleanHouse.Dialogs.Question;
using Plugin.CurrentActivity;

namespace CleanHouse.Services.Impls
{
    public class DialogService : IDialogService
    {
        private readonly ICurrentActivity _currentActivity;

        public DialogService(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;
        }

        public void ShowQuestionDialog(QuestionDialogConfig config) 
            => new QuestionDialog(config, _currentActivity.Activity).Show();
    }
}