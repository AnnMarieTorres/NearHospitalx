// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: BaseShare
// Vers: 5.1.0.0
//
// Share your app experience
// ..............................................................
using System;
using System.Threading.Tasks;
using NearHspt.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseShare : ContentPage
  {

    public BaseShare() 
    {
      InitializeComponent();

      this.Title = "Share this App";
      BackgroundColor = Color.Black;

      _ = ShareTest.ShareText(shareLabel.Text);

    }

    private async void SfButton_Share_Clicked(object sender, EventArgs e)
    {
      await ShareTest.ShareText(shareLabel.Text);
    }
  }

  public static class ShareTest
  {
    public static Task ShareText(string shtext)
    {
      var aa = shtext + "-";
      return Share.RequestAsync(new ShareTextRequest
      {
        Text = AppResources.BaseShareText,
        Title = "Share Text"
      });
    }

  }
}
