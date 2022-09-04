using System;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.DrawerLayout.Widget;
using CleanHouse.MviCommon;
using CleanHouse.Services.Global;
using CleanHouse.Services.Global.Drawer;
using Google.Android.Material.Navigation;

namespace CleanHouse.Ui.Globals.Drawer
{
    public class NavigationDrawerFragment : BaseFragment, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override int LayoutViewId => Resource.Layout.drawer_navigation_fragment;

        private readonly GlobalDrawerController _globalDrawerController;
        private readonly GlobalToolbarController _globalToolbarController;

        public NavigationDrawerFragment(
            GlobalDrawerController globalDrawerController, 
            GlobalToolbarController globalToolbarController)
        {
            _globalDrawerController = globalDrawerController;
            _globalToolbarController = globalToolbarController;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            var navigationDrawerFragment = view.FindViewById<NavigationView>(Resource.Id.drawer_navigation_view);
            var drawer = view.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationDrawerFragment?.SetNavigationItemSelectedListener(this);
            
            _globalDrawerController.Init(this.FragmentManager);
            
            var toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);

            // this is deprecated, don't know how to fix this yet
            drawer.SetDrawerListener(toggle);

            toggle.SyncState();
            
            _globalDrawerController.GlobalDrawerState.State.Subscribe(state =>
            {
                switch (state)
                {
                    case GlobalDrawerState.OnIsOpenChanged isOpenChanged:
                    {
                        if (isOpenChanged.IsOpen)
                            drawer?.OpenDrawer(GravityCompat.Start, true);
                        else
                            drawer?.CloseDrawer(GravityCompat.End, true);
                        return;
                    }
                    case GlobalDrawerState.OnScreenChanged screenChanged:
                    {
                        screenChanged.MenuItem.SetChecked(true);
                        _globalToolbarController.Toolbar.TitleFormatted = screenChanged.MenuItem.TitleFormatted;
                        return;
                    }
                }
            });
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            _globalDrawerController.GlobalDrawerEvent.Emit(new GlobalDrawerEvent.NavigateTo(menuItem));
            return true;
        }
    }
}