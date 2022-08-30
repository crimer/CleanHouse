
namespace CleanHouse.Presenters.Login
{
    public class LoginState : BaseState<LoginState>
    {
        public class AuthValidationFail : LoginState
        {
            public string ErrorMessage { get; }

            public AuthValidationFail(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
        public class AuthSuccess : LoginState { }
        public class AuthError : LoginState { }
    }
}