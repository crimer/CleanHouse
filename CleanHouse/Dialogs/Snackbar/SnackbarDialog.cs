using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using CleanHouse.Application.DialogConfigs;

namespace CleanHouse.Dialogs.Snackbar
{
    public sealed class SnackbarDialog
    {
        public void Show(SnackbarConfig config, Activity activity, Context context)
        {
            var (color, actionTextColor, icon) = GetSettings(config.Type);

            var snackBar = Android.Support.Design.Widget.Snackbar.Make(
                activity.FindViewById(Android.Resource.Id.Content), 
                config.Message, 
                config.Duration);
            
            var view = snackBar.View;
            view.SetBackgroundColor(context.Resources.GetColor(color));
            view.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            {
                Gravity = GravityFlags.Bottom,
            };
            
            if (config.Action != null)
                snackBar.SetAction(config.ActionText, (_) => config?.Action?.Invoke());

            if (!string.IsNullOrWhiteSpace(config.ActionText))
                snackBar.SetActionTextColor(context.Resources.GetColor(actionTextColor));

            var snackBarActionText = snackBar.View.FindViewById<TextView>(Resource.Id.snackbar_action);
            snackBarActionText?.SetTextSize(Android.Util.ComplexUnitType.Dip, 16);
            
            var snackBarMessage = snackBar.View.FindViewById<TextView>(Resource.Id.snackbar_text);
            snackBarMessage.SetTextColor(Color.White);
            snackBarMessage.SetTextSize(Android.Util.ComplexUnitType.Dip, 16);
            snackBarMessage.SetCompoundDrawablesWithIntrinsicBounds(icon, 0, 0, 0);
            snackBarMessage.Gravity = GravityFlags.Center;
            
            snackBar.Show();
        }

        private (int BgColor, int ActionTextColor, int Icon) GetSettings(SnackbarConfig.SnackbarType snackbarType) =>
            snackbarType switch
            {
                SnackbarConfig.SnackbarType.Info => (Resource.Color.colorInfo, Resource.Color.black, Resource.Drawable.ic_info),
                SnackbarConfig.SnackbarType.Error => (Resource.Color.colorError, Resource.Color.black, Resource.Drawable.ic_error),
                SnackbarConfig.SnackbarType.Success => (Resource.Color.colorSuccess, Resource.Color.black, Resource.Drawable.ic_check),
                SnackbarConfig.SnackbarType.Warning => (Resource.Color.colorWarning, Resource.Color.black, Resource.Drawable.ic_warning),
                _ => (Resource.Color.colorInfo, Resource.Color.black, Resource.Drawable.ic_info)
            };
    }
}