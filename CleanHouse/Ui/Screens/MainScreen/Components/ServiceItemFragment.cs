using Android.OS;
using Android.Views;
using Android.Widget;
using CleanHouse.Ui.Globals;

namespace CleanHouse.Ui.Screens.MainScreen.Components
{
    public class ServiceItemFragment : BaseFragment, View.IOnClickListener
    {
        private readonly string _serviceName;
        private readonly int _serviceIconResId;
        protected override int LayoutViewId => Resource.Layout.fragment_main_service_item;

        public ServiceItemFragment(string serviceName, int serviceIconResId)
        {
            _serviceName = serviceName;
            _serviceIconResId = serviceIconResId;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_main_service_item, null);
            SetUpView(view);
            return view;
        }

        private void SetUpView(View view)
        {
            if(view == null)
                return;

            var serviceName = view.FindViewById<TextView>(Resource.Id.main_service_item_name);
            var serviceIcon = view.FindViewById<ImageView>(Resource.Id.main_service_item_icon);
            var serviceItem = view.FindViewById<LinearLayout>(Resource.Id.main_service_item);

            serviceItem.SetOnClickListener(this);

            if (serviceName != null) 
                serviceName.Text = _serviceName;

            if (serviceIcon != null) 
                serviceIcon.SetImageResource(_serviceIconResId);
        }

        public void OnClick(View v)
        {
            
        }

    }
}