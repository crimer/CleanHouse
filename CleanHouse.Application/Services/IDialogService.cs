using System;
using CleanHouse.Application.DialogConfigs;

namespace CleanHouse.Application.Services
{
    public interface IDialogService
    {
        void ShowSnackbar(SnackbarConfig.SnackbarType type, string message, string actionText = "", Action action = null);
        void ShowQuestionDialog(QuestionDialogConfig config);
        void ShowLoading();
        void HideLoading();
    }
}