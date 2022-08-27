using Microsoft.Extensions.Logging;

namespace CleanHouse.Application.Helpers
{
    public class FetchSave
    {
        private readonly DialogService _dialogService;
        private readonly ILogger<FetchSave> _appLogger;

        /// <summary>
        /// В процессе выполнения действия
        /// </summary>
        public bool IsBusy { get; private set; }

        public FetchSave(DialogService dialogService, ILogger<FetchSave> appLogger)
        {
            _dialogService = dialogService;
            _appLogger = appLogger;
        }
        
        /// <summary>
        /// Безопастная подгрузка
        /// </summary>
        /// <param name="task">Таска</param>
        /// <param name="showLoading">Загразка</param>
        /// <param name="loadingMessage">Сообщение закгрузки</param>
        public async Task HandleAsync(Func<Task> task, bool showLoading = true, string loadingMessage = "Загрузка")
        {
            try
            {
                if (IsBusy) return;
                IsBusy = true;

                if (showLoading)
                    _dialogService.ShowLoading(loadingMessage);
                
                // if (!_connectivity.IsConnected)
                // {
                //     await _dialogService.OpenInfoDialogAsync("Внимание","Нет подключения к сети");
                //     return;
                // }
                
                await task();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                _dialogService.HideLoading();
                _appLogger.LogError("Во время безопасной обработке данных произошла ошибка", ex);
            }
            finally
            {
                IsBusy = false;
                if (showLoading) 
                    _dialogService.HideLoading();
            }
        }
    }
}