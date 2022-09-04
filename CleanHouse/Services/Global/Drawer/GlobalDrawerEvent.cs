using Android.Views;
using CleanHouse.MviCommon;

namespace CleanHouse.Services.Global.Drawer
{
    public class GlobalDrawerEvent : BaseEvent<GlobalDrawerEvent>
    {
        public class DrawerOpen : GlobalDrawerEvent { }
        public class DrawerClose : GlobalDrawerEvent { }
        public class NavigateTo : GlobalDrawerEvent
        {
            public IMenuItem MenuItem { get; }

            public NavigateTo(IMenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }
    }
}