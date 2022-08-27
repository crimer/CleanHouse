using System.Windows.Input;

namespace CleanHouse.Application.DialogConfigs
{
    public class QuestionDialogConfig
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string OkText { get; set; }
        public string CancelText { get; set; }
        public bool IsCancelable { get; set; } = true;
        public ICommand OnOkCommand { get; set; }
        public ICommand OnCancelCommand { get; set; }
    }
}