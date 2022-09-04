using System;
using CleanHouse.MviCommon;
using CleanHouse.Ui;
using CleanHouse.Ui.Globals;
using Microsoft.Extensions.DependencyInjection;

namespace CleanHouse.Services.Global
{
    public class GlobalNavigationController
    {
        private readonly IServiceProvider _serviceProvider;
        private AppActivity _appActivity;
        private int _mainActivityContainerId;

        public GlobalNavigationController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public void Init(AppActivity appActivity, int mainActivityContainerId)
        {
            _appActivity = appActivity;
            _mainActivityContainerId = mainActivityContainerId;
        }
        
        public void SetRootScreen<TFragment>() where TFragment : BaseFragment
        {
            var fragment = _serviceProvider.GetRequiredService<TFragment>();

            _appActivity.SupportFragmentManager
                .BeginTransaction()
                .Replace(_mainActivityContainerId, fragment)
                .Commit();
        }
    }
}