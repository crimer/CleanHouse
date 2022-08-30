using System.Threading.Tasks;
using Android.Content;
using CleanHouse.Application.Extensions;
using CleanHouse.Application.Helpers;
using FluentResults;
using Java.Lang;
using Microsoft.Extensions.Logging;

namespace CleanHouse.Presenters.Login
{
    public class LoginPresenter : BasePresenter
    {
        private readonly FetchSave _fetchSave;
        private readonly ILogger<LoginPresenter> _logger;
        public LoginState LoginState { get; } = new LoginState();

        public LoginPresenter(FetchSave fetchSave, ILogger<LoginPresenter> logger)
        {
            _fetchSave = fetchSave;
            _logger = logger;
        }

        public async Task SubmitLoginAsync(string email, string password)
        {
            try
            {
                await _fetchSave.HandleAsync(async () =>
                {
                    var validation = Validate(email, password);
                    if (validation.IsFailed)
                    {
                        LoginState.Set(new LoginState.AuthValidationFail(validation.Summary()));
                        return;
                    }

                    await Task.Delay(2000);

                    LoginState.Set(new LoginState.AuthSuccess());
                    _logger.LogInformation("Авторизация прошла успешно");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при авторизации");
                LoginState.Set(new LoginState.AuthError());
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