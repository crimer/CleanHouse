using Android.Support.V7.Widget;
using CleanHouse.Ui;

namespace CleanHouse.Services.Global
{
    public class GlobalToolbarController
    {
        public AppActivity AppActivity { get; private set; }
        public Toolbar Toolbar { get; private set; }
        
        public void Init(AppActivity appActivity)
        {
            this.AppActivity = appActivity;
            this.Toolbar = AppActivity.FindViewById<Toolbar>(Resource.Id.toolbar);
        }
    }
}