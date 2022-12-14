using System;
using Android.App;
using Android.Content;
using CleanHouse.Application.DialogConfigs;
using CleanHouse.Application.Services;
using CleanHouse.Ui.Dialogs.Loading;
using CleanHouse.Ui.Dialogs.Question;
using CleanHouse.Ui.Dialogs.Snackbar;
using Plugin.CurrentActivity;

namespace CleanHouse.Services
{
    public class DialogService : IDialogService
    {
        private readonly ICurrentActivity _currentActivity;
        private readonly LoadingDialog _loadingDialog;
        private Activity CurrentActivity => _currentActivity.Activity;
        private Context CurrentContext => _currentActivity.AppContext;

        public DialogService(ICurrentActivity currentActivity)
        {
            _currentActivity = currentActivity;
            _loadingDialog = new LoadingDialog();
        }

        public void ShowSnackbar(SnackbarConfig.SnackbarType type, string message, string actionText = "", Action action = null) 
            => new SnackbarDialog()
                .Show(new SnackbarConfig(type, message, actionText, action), CurrentActivity, CurrentContext);

        public void ShowQuestionDialog(QuestionDialogConfig config) 
            => new QuestionDialog(config, CurrentActivity).Show();

        public void ShowLoading() => _loadingDialog.Show(CurrentActivity);
        public void HideLoading() => _loadingDialog.Hide();
    }
}