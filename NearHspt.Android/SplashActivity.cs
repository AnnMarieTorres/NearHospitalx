// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: SplashActivity
// Vers: 5.1.0.0
//
// Creates the splash page (ahead of all other mod's)
// .............................................................
using Android.Animation;
using Android.App;
using Android.OS;
using Android.Widget;
using NearHspt.Droid;

namespace NearHspt.Droid
{
  [Activity(Label = "All Nearby ER.Hospitals", Theme = "@style/Theme.Splash", Icon = "@drawable/fng", MainLauncher = true, NoHistory = true)]
  public class SplashActivity : Activity
  {
    ValueAnimator animator;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetContentView(Resource.Layout.SplashLayout);
      System.Threading.ThreadPool.QueueUserWorkItem(o => LoadActivity());

      TextView companyName = FindViewById<TextView>(Resource.Id.mCNLabel);
      companyName.TextSize = 18;

      animator = ValueAnimator.OfInt(18, 44);
      animator.Update += (object sender, ValueAnimator.AnimatorUpdateEventArgs e) =>
      {
        int newValue = (int)e.Animation.AnimatedValue;
        companyName.TextSize = newValue;
      };
    }

    private void LoadActivity()
    {
      System.Threading.Thread.Sleep(5000); // Simulate a long pause
      RunOnUiThread(() => StartActivity(typeof(MainActivity)));
    }

    public override void OnWindowFocusChanged(bool hasFocus)
    {
      ImageView imageView = FindViewById<ImageView>(Resource.Id.animated_loading);
      global::Android.Graphics.Drawables.AnimationDrawable animation = (global::Android.Graphics.Drawables.AnimationDrawable)imageView.Drawable;
      animation.Start();

      animator.RepeatCount = 1;
      animator.SetDuration(10000);
      animator.Start();
    }
  }
}