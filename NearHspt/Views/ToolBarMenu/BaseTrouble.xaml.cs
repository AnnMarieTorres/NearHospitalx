// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Base Troubleshooting
// Vers: 5.1.0.0
//
// Lists a few tips re: GPS, Geo, Performance
// .............................................................
using System;
//grb//using Plugin.Permissions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseTrouble : ContentPage
  {

    public BaseTrouble()
    {
      InitializeComponent();

      this.Title = "Troublehooting";
      BackgroundColor = Color.White;
    }

    private void displaySystemSettings_Clicked(object sender, EventArgs e)
    {
      //grb//CrossPermissions.Current.OpenAppSettings();
    }
  }
}
