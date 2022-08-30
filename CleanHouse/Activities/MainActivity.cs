using Android.App;
using Android.Widget;
using CleanHouse.Activities;
using CleanHouse.Presenters.Main;
using EBind;

namespace CleanHouse.Pages
{
    [Activity(Theme = "@style/AppTheme")]
    public class MainActivity : BaseActivity<MainPresenter>
    {
        private EBinding _bindings;
        protected override int LayoutViewId => Resource.Layout.activity_main;
        protected override MainPresenter Presenter { get; set; }
        
        protected override void SetUpBindings()
        {
            var editTextEntry = FindViewById<EditText>(Resource.Id.edittext);
            var btnShowPopup = FindViewById<Button>(Resource.Id.btnPopup);
            var btnShowToast = FindViewById<Button>(Resource.Id.btnToast);

            _bindings = new EBinding()
            {
                (btnShowPopup, nameof(btnShowPopup.Click), () => Presenter.ShowPopup()),
                (btnShowToast, nameof(btnShowToast.Click), () => Presenter.ShowToast()),
            };
        }

        protected override void Dispose() => _bindings.Dispose();
    }
}