using CleanHouse.MviCommon;

namespace CleanHouse.Ui.Screens.LoginScreen.Presenters
{
    public class LoginState : BaseState<LoginState>
    {
        public class AuthSuccess : LoginState { }
        public class AuthError : LoginState { }
        public class AuthValidationFail : LoginState
        {
            public string ErrorMessage { get; }

            public AuthValidationFail(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
        public class Loading : LoginState
        {
            public bool IsLoading { get; }

            public Loading(bool isLoading)
            {
                IsLoading = isLoading;
            }
        }
    }
}