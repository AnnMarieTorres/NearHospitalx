// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: StatAbout
// Vers: 5.1.0.0
//
// Brief [About] and [Reference] page
// .............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseAbout : ContentPage
  {


    public BaseAbout()
    {
      InitializeComponent();


      Title = "About";
      BackgroundColor = Color.Black;

      content100.Text = "\n  App Name.......: " + App.AppName +
        "\n   App Version...: " + App.AppVersion +
        "\n   Release Date.: " + App.RelDate +
        "\n   Reg Number...: " + App.RegNum +
        "\n\n  Copyright (2019,2020,2021):\n" +
        "  CNG Internet Software, LLC.\n" + 
        "  All rights reserved.\n\n";
    }


    private async void moreInfo_Clicked(object sender, System.EventArgs e)
    {
      await Browser.OpenAsync("https://www.cnginternetsoftware.com/smart_phone_software", BrowserLaunchMode.SystemPreferred);
    }
  }
}