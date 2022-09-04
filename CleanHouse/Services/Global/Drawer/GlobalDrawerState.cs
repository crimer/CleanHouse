using Android.Views;
using CleanHouse.Application.Models.Enums;
using CleanHouse.MviCommon;

namespace CleanHouse.Services.Global.Drawer
{
    public class GlobalDrawerState : BaseState<GlobalDrawerState>
    {
        public class OnScreenChanged : GlobalDrawerState
        {
            public IMenuItem MenuItem { get; }

            public OnScreenChanged(IMenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }

        public class OnIsOpenChanged : GlobalDrawerState
        {
            public bool IsOpen { get; }

            public OnIsOpenChanged(bool isOpen)
            {
                IsOpen = isOpen;
            }
        }
    }
}