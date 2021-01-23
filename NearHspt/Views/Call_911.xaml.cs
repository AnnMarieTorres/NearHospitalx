// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Call_911
// Vers: 5.1.0.0
//
// Call 911 routine
// .............................................................
using System.Linq;
using Xamarin.Forms;
using NearHspt.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System;

namespace NearHspt.Views
{
    public partial class Call_911 : ContentPage
    {
        public Call_911()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string listEntryName = (e.CurrentSelection.FirstOrDefault() as DB_01_Items).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"single002_route_details?name={listEntryName}");
      // The full route is shown below.
      // await Shell.Current.GoToAsync($"//flyoutItemRoute/single02Route/single002_route_details?name={listEntryName}");
    }


    // =======================================================================
    // Small Help Button, next to [ start/ refresh ]
    //
    // =======================================================================
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
      //grb//await Util100.DisplaySfPopupAlert(AppResources.AlertFirstQuestionHd, AppResources.AlertFisrtQuestion, "  Neat  ", "");
      await Navigation.PushAsync(new Single002DetailPage());
    }

    private void DialButton_Clicked(object sender, EventArgs e)
    {
            try
            {
                PhoneDialer.Open(EntryNumber.Text);
      }
            catch (Exception)
            {
                _ = DisplayAlert("Unable to Call", "Please enter a number, like 911.", "OK");
      }
    }
  }
}
