using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Android.Widget;

namespace NearHspt.Droid
{
  //[Activity(Label = "NearHspt", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  [Activity(Label = "All Nearby ER.Hospitals", Icon = "@mipmap/fng", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0));
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

    // ................................................................................................
    // OnRequestPermissionsResult
    // 
    // Required by Xamarin Essentials to 'connect' to Permission
    // ................................................................................................
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

 
#region Backpress functions

bool _isBackPressed = false;

    // ===================================================================================
    //
    //
    // ===================================================================================
    public override void OnBackPressed()
    {
      var app = (NearHspt.App)App.Current;
      //if (app.PromptToConfirmExit)
      {
        //if (app.IsToastExitConfirmation)
        //   ConfirmWithToast();
        //else
        ConfirmWithDialog();

        return;
      }
      //grb//base.OnBackPressed();
    }

    private void ConfirmWithDialog()
    {
      string Exit001xx = "";
      string Exit002xx = "";
      string Exit003xx = "";
      string Exit004xx = "";
      using (var alert = new AlertDialog.Builder(this))
      {
        //
        // set language culture for the two language switches
        // Stored in Alles.CLanguage
        // English "en"  --> "en-US" 
        // Spanish "es"
        //
        if (Alles.CLanguage.ToLower() == "en")
        {
          // This is hard-coded, since the App Resources can't be 'reached' from MainActivity.
          Exit001xx = "Exit from \"Near Hospital T\"";
          Exit002xx = "\nAre you sure you want to exit?";
          Exit003xx = "Yes";
          Exit004xx = "No";
        }
        else if (Alles.CLanguage.ToLower() == "es")
        {
          // This is hard-coded, since the App Resources can't be 'reached' from MainActivity.
          Exit001xx = "Salga de \"Near Hospital T\"";
          Exit002xx = "\n¿Estás seguro de que quieres salir?";
          Exit003xx = "Si";
          Exit004xx = "No";
        }
        //
        alert.SetTitle(Exit001xx);
        alert.SetMessage(Exit002xx);
        alert.SetPositiveButton(Exit003xx, (sender, args) => { FinishAffinity(); });
        alert.SetNegativeButton(Exit004xx, (sender, args) => { }); // do nothing

        var dialog = alert.Create();
        //
        // ready for background work
        //
        //////////////////////////////////////////////////////////////////////////////////Alles.backgroundReady = true;
        //
        dialog.Show();
      }
      return;
    }

    private void ConfirmWithToast()
    {
      if (_isBackPressed)
      {
        FinishAffinity(); // inform Android that we are done with the activity
        return;
      }

      _isBackPressed = true;
      Toast.MakeText(this, "Press back again to exit", ToastLength.Short).Show();

      // Disable back to exit after 2 seconds.
      new Handler().PostDelayed(() => { _isBackPressed = false; }, 2000);
      return;
    }


    #endregion


  }
}
