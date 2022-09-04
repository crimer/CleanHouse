
using CleanHouse.MviCommon;

namespace CleanHouse.Ui.Screens.LoginScreen.Presenters
{
    public class LoginEvent : BaseEvent<LoginEvent>
    {
        public LoginState LoginState { get; }

        public LoginEvent(LoginState loginState)
        {
            LoginState = loginState;
        }

        public class AuthSubmit : LoginEvent
        {
            public string Login { get; }
            public string Password { get; }

            public AuthSubmit(string login, string password, LoginState loginState) : base(loginState)
            {
                Login = login;
                Password = password;
            }
        }
    }
}