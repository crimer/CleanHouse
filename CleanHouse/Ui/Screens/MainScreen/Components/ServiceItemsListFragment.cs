using System.Collections.ObjectModel;
using Android.OS;
using Android.Views;
using CleanHouse.Ui.Globals;

namespace CleanHouse.Ui.Screens.MainScreen.Components
{
    public class ServiceItemsListFragment : BaseFragment
    {
        private View _view;
        private Collection _serviceItemsList;
        protected override int LayoutViewId => Resource.Layout.fragment_main_service_item;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.fragment_main_service_item, null);
            _serviceItemsList = _view.FindViewById<Collection>(Resource.Id.service_items_list);

            return _view;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        
        public void AddServiceItem(string name, int iconId)
        {
            var item = new ServiceItemFragment(name, iconId);
            _serviceItemsList.Add(item);
        }

    }
}