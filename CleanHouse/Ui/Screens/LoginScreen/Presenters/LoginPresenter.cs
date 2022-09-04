using System;
using System.Threading.Tasks;
using CleanHouse.Application.Extensions;
using CleanHouse.MviCommon;
using CleanHouse.Utils.Extensions;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace CleanHouse.Ui.Screens.LoginScreen.Presenters
{
    public class LoginPresenter : BasePresenter
    {
        private readonly ILogger<LoginPresenter> _logger;
        public readonly LoginState LoginState;
        public readonly LoginEvent LoginEvent;

        public LoginPresenter(ILogger<LoginPresenter> logger)
        {
            _logger = logger;
            
            LoginState = new LoginState();
            LoginEvent = new LoginEvent(LoginState);
            LoginEvent.Event.SubscribeAsync(HandleEvents);
        }
        
        private async Task HandleEvents(LoginEvent loginEvent)
        {
            switch (loginEvent)
            {
                case LoginEvent.AuthSubmit authSubmit:
                {
                    await SubmitLoginAsync(authSubmit.Login, authSubmit.Login);
                    return;
                }
                default:
                    throw new Exception($"Не обрабатывается событие {loginEvent}");
            }
        }

        private async Task SubmitLoginAsync(string email, string password)
        {
            try
            {
                LoginState.Set(new LoginState.Loading(true));

                var validation = Validate(email, password);
                if (validation.IsFailed)
                {
                    LoginState.Set(new LoginState.AuthValidationFail(validation.Summary()));
                    return;
                }

                await Task.Delay(1000);

                LoginState.Set(new LoginState.AuthSuccess());
                _logger.LogInformation("Авторизация прошла успешно");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при авторизации");
                LoginState.Set(new LoginState.AuthError());
            }
            finally
            {
                LoginState.Set(new LoginState.Loading(false));
            }
        }

        private Result Validate(string email, string password)
        {
            if (email.IsNullOrEmpty())
                return Result.Fail("Почта не должна быть пустой");

            if (password.IsNullOrEmpty())
                return Result.Fail("Пароль не должен быть пустой");

            return Result.Ok();
        }
    }
}