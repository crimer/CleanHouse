using System;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;

namespace CleanHouse.Ui.Dialogs.Loading
{
    public class LoadingDialog
    {
        private Dialog _dialog;
        private bool _isOpen = false;
        
        public LoadingDialog Show(Activity activity)
        {
            try
            {
                if (_isOpen)
                    return this;

                _isOpen = true;

                _dialog = new Dialog(activity);

                _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                _dialog.SetCancelable(false);
                _dialog.SetContentView(Resource.Layout.dialog_loading);
                _dialog.Window.SetGravity(GravityFlags.Center);
                _dialog.Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                _dialog.Window.ClearFlags(WindowManagerFlags.DimBehind);
                _dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                _dialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
                _dialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);
                _dialog.Show();
            }
            catch (Exception)
            {
                Hide();
            }

            return this;
        }

        public void Hide()
        {
            if(!_isOpen)
                return;

            _dialog?.Hide();
            _dialog?.Dispose();
            _dialog = null;
            _isOpen = false;
        }
    }
}