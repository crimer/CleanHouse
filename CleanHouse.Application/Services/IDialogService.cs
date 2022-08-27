using CleanHouse.Application.DialogConfigs;

namespace CleanHouse.Application.Services
{
    public interface IDialogService
    {
        void ShowQuestionDialog(QuestionDialogConfig config);
    }
}