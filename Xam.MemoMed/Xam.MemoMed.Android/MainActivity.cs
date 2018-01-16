
using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Messaging;
using ZXing.Mobile;

namespace Xam.MemoMed.Droid
{
    [Activity(Label = "Xam.MemoMed", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            MobileBarcodeScanner.Initialize(Application);

            CrossMessaging.Current.Settings().Email.UseStrictMode = true;

            LoadApplication(new App());
        }
    }
}

