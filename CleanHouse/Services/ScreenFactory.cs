using System;
using System.Collections.Generic;
using CleanHouse.Application.Models.Enums;
using CleanHouse.MviCommon;
using CleanHouse.Ui.Screens.LoginScreen;
using CleanHouse.Ui.Screens.MainScreen;
using Microsoft.Extensions.DependencyInjection;

namespace CleanHouse.Services
{
    public class ScreenFactory
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<int, Type> _screens = new Dictionary<int, Type>()
        {
            {Resource.Id.drawer_menu_services_item, typeof(MainScreen)},
            {Resource.Id.drawer_menu_user_profile_item, typeof(LoginScreen)},
        };

        public ScreenFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseScreen GetScreen(int menuItemResourceId) 
            => _serviceProvider.GetRequiredService(_screens[menuItemResourceId]) as BaseScreen;
    }
}