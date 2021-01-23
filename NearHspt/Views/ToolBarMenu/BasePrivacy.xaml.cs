// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: BasePrivacy
// Vers: 5.1.0.0
//
// Pointing to the CHG Internet Software Privacy page
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BasePrivacy : ContentPage
  {


    public BasePrivacy()
    {
      InitializeComponent();

      this.Title = "Privacy";
      BackgroundColor = Color.Black;
    }

  }
}