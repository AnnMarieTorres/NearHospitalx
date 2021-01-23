// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Disclaimer
// Vers: 5.1.0.0
//
// Legal Disclaimer, short version
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseDisclaimer : ContentPage
  {

    public BaseDisclaimer()
    {
      InitializeComponent();
      Title = "Legal Disclaimer";
      BackgroundColor = Color.Black;
    }

  }
}
