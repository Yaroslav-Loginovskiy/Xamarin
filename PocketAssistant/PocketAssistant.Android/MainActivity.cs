using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace PocketAssistant.Droid
{
    [Activity(Label = "PocketAssistant", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0));
            base.OnCreate(savedInstanceState);
            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        //protected override void OnStart()
        //{

        //}
        //protected override void OnRestart()
        //{
        //    base.OnRestart();
        //}
        protected override void OnStart()
        {
            Log.Debug("OnStart", "OnStart called, App is Active");
            base.OnStart();
        }

        protected override void OnResume()
        {
            Log.Debug("OnResume", "OnResume called, app is ready to interact with the user");
            base.OnResume();
        }

        protected override void OnPause()
        {
            Log.Debug("OnPause", "OnPause called, App is moving to background");
            base.OnPause();
        }

        protected override void OnStop()
        {
            Log.Debug("OnStop", "OnStop called, App is in the background");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("OnDestroy", "OnDestroy called, App is Terminating");
        }

    }
}