// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: BaseHowItWorks
// Vers: 5.1.0.0
//
// Brief Users "manual"
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseHowItWorks : ContentPage
  {

    public BaseHowItWorks()
    {
      InitializeComponent();

      this.Title = "How does it Work";
      BackgroundColor = Color.White;

    }

  }
}
