using System;
using Android.Support.V4.App;
using Android.Views;

namespace CleanHouse.Services.Global.Drawer
{
    public class GlobalDrawerController
    {
        private readonly ScreenFactory _screenFactory;
        public readonly GlobalDrawerEvent GlobalDrawerEvent;
        public readonly GlobalDrawerState GlobalDrawerState;
        private FragmentManager _fragmentManager;

        public GlobalDrawerController(ScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;

            GlobalDrawerState = new GlobalDrawerState();
            GlobalDrawerEvent = new GlobalDrawerEvent();

            GlobalDrawerEvent.Event.Subscribe(HandleEvents);
        }

        public void Init(FragmentManager fragmentManager)
        {
            _fragmentManager = fragmentManager;
        }


        private void HandleEvents(GlobalDrawerEvent globalDrawerEvent)
        {
            switch (globalDrawerEvent)
            {
                case GlobalDrawerEvent.NavigateTo navigateTo:
                {
                    SetDrawerScreen(navigateTo.MenuItem);
                    return;
                }
                case GlobalDrawerEvent.DrawerOpen _:
                {
                    Open();
                    return;
                }
                case GlobalDrawerEvent.DrawerClose _:
                {
                    Close();
                    return;
                }
            }
        }

        private void Open() => GlobalDrawerState.State.OnNext(new GlobalDrawerState.OnIsOpenChanged(true));
        
        private void Close() => GlobalDrawerState.State.OnNext(new GlobalDrawerState.OnIsOpenChanged(false));
        
        
        private void SetDrawerScreen(IMenuItem menuItem)
        {
            var screen = _screenFactory.GetScreen(menuItem.ItemId);

            _fragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.drawer_main_container, screen)
                .Commit();

            Close();

            GlobalDrawerState.State.OnNext(new GlobalDrawerState.OnScreenChanged(menuItem));
        }
    }
}