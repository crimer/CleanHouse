using System.Threading.Tasks;
using CleanHouse.Application.DialogConfigs;
using CleanHouse.Application.Services;
using CleanHouse.MviCommon;
using Microsoft.Extensions.Logging;

namespace CleanHouse.Ui.Screens.MainScreen.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private readonly ILogger<MainPresenter> _logger;
        private readonly IDialogService _dialogService;
        public MainState MainState { get; } = new MainState();

        public MainPresenter(ILogger<MainPresenter> logger, IDialogService dialogService)
        {
            _logger = logger;
            _dialogService = dialogService;
        }

        public async Task ShowToast()
        {
            _dialogService.ShowSnackbar( SnackbarConfig.SnackbarType.Success,"Проверка");
        }

        public async Task ShowPopup()
        {
            _dialogService.ShowLoading();

            await Task.Delay(2000);
            _dialogService.HideLoading();
        }
    }
}