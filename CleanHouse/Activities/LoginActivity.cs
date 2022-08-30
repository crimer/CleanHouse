using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using CleanHouse.Application.DialogConfigs;
using CleanHouse.Pages;
using CleanHouse.Presenters.Login;
using EBind;

namespace CleanHouse.Activities
{
    [Activity(Theme = "@style/AppTheme.Login")]
    public class LoginActivity : BaseActivity<LoginPresenter>
    {
        private EBinding _bindings;
        protected override int LayoutViewId => Resource.Layout.activity_login;
        protected override LoginPresenter Presenter { get; set; }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Presenter.LoginState.State.Subscribe(state =>
            {
                switch (state)
                {
                    case LoginState.AuthError _:
                        DialogService.ShowSnackbar( SnackbarConfig.SnackbarType.Error,"Во время авторизации произошла ошибка");
                        break;
                    case LoginState.AuthValidationFail authValidationFail:
                        DialogService.ShowSnackbar(SnackbarConfig.SnackbarType.Warning, authValidationFail.ErrorMessage);
                        break;
                    case LoginState.AuthSuccess _:
                        DialogService.ShowSnackbar( SnackbarConfig.SnackbarType.Success,"Авторизация прошла успешно");
                        StartActivity(new Intent(Android.App.Application.Context, typeof(MainActivity)));
                        break;
                }
            });
        }

        protected override void SetUpBindings()
        {
            var loginEmailEntry = FindViewById<EditText>(Resource.Id.login_mail_entry);
            var loginPassEntry = FindViewById<EditText>(Resource.Id.login_pass_entry);
            var loginButton = FindViewById<FloatingActionButton>(Resource.Id.login_submit);

            _bindings = new EBinding()
            {
                BindFlag.TwoWay,
                (loginButton, nameof(loginButton.Click), () => Presenter.SubmitLoginAsync(loginEmailEntry.Text, loginPassEntry.Text)),
            };
        }

        protected override void Dispose()
        {
            _bindings.Dispose();
            _bindings = null;
        }
    }
}