using System;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using CleanHouse.Application.DialogConfigs;
using CleanHouse.MviCommon;
using CleanHouse.Services.Global;
using CleanHouse.Ui.Globals.Drawer;
using CleanHouse.Ui.Screens.LoginScreen.Presenters;

namespace CleanHouse.Ui.Screens.LoginScreen
{
    public class LoginScreen : BaseScreen<LoginPresenter>, View.IOnClickListener
    {
        protected override int LayoutViewId => Resource.Layout.screen_login;
        private readonly GlobalNavigationController _globalNavigationController;

        public LoginScreen(GlobalNavigationController globalNavigationController)
        {
            _globalNavigationController = globalNavigationController;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            var loginButton = view.FindViewById<FloatingActionButton>(Resource.Id.login_submit);
            loginButton?.SetOnClickListener(this);

            Presenter.LoginState.State.Subscribe(HandleState);
        }
        
        public void OnClick(View button)
        {
            var loginEmailEntry = View.FindViewById<EditText>(Resource.Id.login_mail_entry);
            var loginPassEntry = View.FindViewById<EditText>(Resource.Id.login_pass_entry);

            Presenter.LoginEvent.Emit(new LoginEvent.AuthSubmit(
                loginEmailEntry?.Text, 
                loginPassEntry?.Text,
                Presenter.LoginState));
        }
        
        private void HandleState(LoginState state)
        {
            switch (state)
            {
                case LoginState.AuthError _:
                    DialogService.ShowSnackbar(SnackbarConfig.SnackbarType.Error, "Во время авторизации произошла ошибка");
                    return;
                case LoginState.AuthValidationFail authValidationFail:
                    DialogService.ShowSnackbar(SnackbarConfig.SnackbarType.Warning, authValidationFail.ErrorMessage);
                    return;
                case LoginState.AuthSuccess _:
                    DialogService.ShowSnackbar(SnackbarConfig.SnackbarType.Success, "Авторизация прошла успешно");
                    _globalNavigationController.SetRootScreen<NavigationDrawerFragment>();
                    return;
                case LoginState.Loading loading:
                    if (loading.IsLoading)
                        this.DialogService.ShowLoading();
                    else
                        this.DialogService.HideLoading();
                    return;
            }
        }
    }
}