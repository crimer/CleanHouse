using Android.App;
using Android.Views;
using Android.Widget;
using CleanHouse.Application;
using CleanHouse.Application.DialogConfigs;
using EBind;
using Microsoft.Extensions.DependencyInjection;

namespace CleanHouse.Ui.Dialogs.Question
{
    public sealed class QuestionDialog : Dialog
    {
        private EBinding _binding;
        private readonly Utils.Utils _utils = AppDependencies.ServiceProvider.GetRequiredService<Utils.Utils>();

        public QuestionDialog(QuestionDialogConfig config, Activity activity) : base(activity)
        {
            var view = LayoutInflater.Inflate(Resource.Layout.dialog_question, null);

            var buttonOk = view.FindViewById<Button>(Resource.Id.btnOk);
            var buttonCancel = view.FindViewById<Button>(Resource.Id.btnCancel);
            var customTitle = view.FindViewById<TextView>(Resource.Id.allocate_collector);

            _binding = new EBinding()
            {
                BindFlag.TwoWay,
                () => customTitle.Text == config.Text,
                () => buttonOk.Text == config.OkText,
                () => buttonCancel.Text == config.CancelText,
                (buttonOk, nameof(buttonOk.Click), () => config.OnOkCommand?.Execute(null)),
                (buttonCancel, nameof(buttonCancel.Click), () => config.OnCancelCommand?.Execute(null)),
            };

            SetContentView(view);
            SetTitle(config.Title);
            SetCancelable(config.IsCancelable);
            SetCanceledOnTouchOutside(config.IsCancelable);
            
            Window.SetSoftInputMode(SoftInput.AdjustResize);

            var sizes = _utils.GetDevicePercentagesSize(config.WidthPercentages, config.HeightPercentages);
            
            Window.SetLayout((int)sizes.width, (int)sizes.height);  
            Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);
        }

        protected override void Dispose(bool disposing)
        {
            _binding.Dispose();
            _binding = null;
            base.Dispose(disposing);
        }
    }
}