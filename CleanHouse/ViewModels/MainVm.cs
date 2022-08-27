using System.Diagnostics;
using System.Windows.Input;
using CleanHouse.Application.Commands;
using CleanHouse.Application.DialogConfigs;
using CleanHouse.Application.Services;

namespace CleanHouse.ViewModels
{
    public class MainVm : BaseVm
    {
        private readonly IDialogService _dialogService;
        public ICommand OnTextChangedCommand { get; set; }
        public ICommand OpenDialogCommand { get; set; }

        public MainVm(IDialogService dialogService)
        {
            _dialogService = dialogService;
            
            OnTextChangedCommand = new ActionCommand<string>(OnTextChanged);
            OpenDialogCommand = new ActionCommand<int>(OpenDialog);
            OnOkCommand = new ActionCommand(OnOk);
        }

        private void OnOk()
        {
            
        }

        public ICommand OnOkCommand { get; set; }

        private void OpenDialog(int obj)
        {
            _dialogService.ShowQuestionDialog(new QuestionDialogConfig()
            {
                Title = "Как Дела?",
                Text = "Вопросник",
                CancelText = "Никак",
                OkText = "Класс",
                OnOkCommand = OnOkCommand
            });
        }

        private void OnTextChanged(string text)
        {
            Debug.WriteLine($"Handle - {text}");
        }
    }
}