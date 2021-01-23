// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: FindHospital
// Vers: 5.1.0.0
//
// First Major. List nearest hospital, get list of all in 
// 100 miles, 100 count, get current location, Google map
// .............................................................
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NearHspt.AA_Utilities;
using NearHspt.Models;
using NearHspt.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class FindHospital : ContentPage
  {

    public FindHospital()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "Nearest Hospitals/ER";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;

      #endregion

    }


    // =======================================================================
    // On appearing:
    //
    // =======================================================================
    protected override async void OnAppearing()
    {
      int pCount = Preferences.Get("manageRepeatgeoPermission", 9999);
      base.OnAppearing();
      if (pCount < 2)
      {
        pCount++;
        Preferences.Set("manageRepeatgeoPermission", pCount);
        await refresh_GEO_addresslines();
      }
    }


    // =======================================================================
    // On Disappearing
    //
    // =======================================================================
    protected override void OnDisappearing()
    {
      base.OnDisappearing();
    }


    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // =======================================================================
    // Refresh the (new) geo location, 
    // and show the (new) address under "My Address via GPS ..."
    //
    // =======================================================================
    private async System.Threading.Tasks.Task refresh_GEO_addresslines()
    {
      //
      // get geo location, and all details
      //
      await GeoSupport.GetLatitude_LongitudeAsync();
      lbMyAddress.Text = Alles.lbMyAddressGlobal;
      // Important error
      if (App.majorGEOerror)
      {
        await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoLatLong, "OK");
        return;
      }
      GeoSupport.Create_NearDBIndex();
      await GeoSupport.SetAddressbtContents(this.btdisplayAllHospitals, this.btNearestHospital, this.lbMyAddress);
      if (App.majorGEOerror)
      {
        await DisplayAlert(AppResources.AlertNoInternetHD, AppResources.AlertNoInternet, "OK");
        return;
      }
    }


    // =======================================================================
    // Small Help Button, next to [ start/ refresh ]
    //
    // =======================================================================
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
      await DisplayAlert(AppResources.AlertFirstQuestionHd, AppResources.AlertFisrtQuestion, "OK");
    }



    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // Button service routines
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



    // =======================================================================
    // Google Address, and fastest route to nearest hospital
    //
    // =======================================================================
    private async void MyAddress_Tapped(object sender, EventArgs e)
    {
      // 
      // assure it's not an 'empty' button
      //
      string temp1 = " No GPS Data yet";
      int temp1l = temp1.Length;
      string temp2 = lbMyAddress.Text.Substring(0, temp1l);
      if (temp1 == temp2)
      {
        await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoHospitalYet, "OK");
        return;
      }
      _ = GeoSupport.ActualAddressMap();
    }



    // =======================================================================
    // Google Id for Nearest Hospital
    //
    // =======================================================================
    private async void btNearestHospital_ClickedAsync(object sender, EventArgs e)
    {
      // 
      // assure it's not an 'empty' button
      //
      try
      {
        string temp1 = "No GPS Data yet";
        int temp1l = temp1.Length;
        string temp2 = btNearestHospital.Text.Substring(0, temp1l);
        if (temp1 == temp2)
        {
          await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoHospitalYet, "OK"); //"  Got It  ", "");
          return;
        }
      }
      catch (Exception stre)
      {
        _ = stre.Message.ToString();
        await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoHospitalYet, "OK");
      }
      //
      App.selectedHospital = App.hospitalsInRange[0, 0];
      string searchStr = "https://www.google.com/search?q=%22";
      searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," +
        App.hospitalsDB[App.selectedHospital, 3] + "," +
        App.hospitalsDB[App.selectedHospital, 4];
      searchStr += "%22";

      await Browser.OpenAsync(searchStr, BrowserLaunchMode.SystemPreferred);
    }



    // =======================================================================
    // Display all (100 miles, 100 count) hospitals
    //
    // =======================================================================
    private async void btdisplayAllHospitals_Clicked(object sender, EventArgs e)
    {
      // 
      // assure it's not an 'empty' button
      //
      try
      {
        string temp1 = "Ready For...";
        int temp1l = temp1.Length;
        string temp2 = btdisplayAllHospitals.Text.Substring(0, temp1l);
        if (temp1 == temp2)
        {
          await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoHospitalYet, "OK");
          return;
        }
      }
      catch (Exception stre)
      {
        _ = stre.Message.ToString();
        await DisplayAlert(AppResources.AlertNoHospitalYetH, AppResources.AlertNoHospitalYet, "OK");
      }
      //

      await Navigation.PushAsync(new HospitalList());
    }




    // =======================================================================
    // Start / Refresh, and show progress bar
    //
    // =======================================================================
    private async void btRefresh_Clicked(object sender, EventArgs e)
    {
      await refresh_GEO_addresslines();
    }

    // =======================================================================
    // Small Help Button, next to [ start/ refresh ]
    //
    // =======================================================================
    private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
      await DisplayAlert(AppResources.AlertFirstQuestionHd, AppResources.AlertFisrtQuestion, "OK");
    }
  }
}
