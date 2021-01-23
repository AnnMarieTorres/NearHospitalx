// ..............................................................
// Copyright @ 2019, 2020  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: BaseHowItWorks
// Vers: 3.1.14.8
//
// Brief Users "manual"
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseListGuide : ContentPage
  {

    public BaseListGuide()
    {
      InitializeComponent();

      this.Title = "Listing Tips";
      BackgroundColor = Color.White;

    }

  }
}
