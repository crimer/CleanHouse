using Android.App;
using Android.Widget;
using CleanHouse.ViewModels;
using EBind;

namespace CleanHouse.Pages
{
    [Activity(
        Label = "@string/app_name", 
        Theme = "@style/AppTheme", 
        MainLauncher = true)]
    public class MainActivity : BaseActivity<MainVm>
    {
        private EBinding _bindings;
        protected override int LayoutViewId => Resource.Layout.main_activity;
        protected override MainVm ViewModel { get; set; }
        
        protected override void SetUpBindings()
        {
            var editTextEntry = FindViewById<EditText>(Resource.Id.edittext);
            var btnShowPopup = FindViewById<Button>(Resource.Id.btnPopup);

            _bindings = new EBinding()
            {
                (editTextEntry, nameof(editTextEntry.TextChanged), () => ViewModel.OnTextChangedCommand?.Execute(editTextEntry.Text)),
                (btnShowPopup, nameof(btnShowPopup.Click), () => ViewModel.OpenDialogCommand?.Execute(Resource.Layout.dialog_question)),
            };
        }

        protected override void Dispose()
        {
            _bindings.Dispose();
        }
    }
}