// ..............................................................
// Copyright @ 2019, 2020  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: BaseGuide
// Vers: 3.1.14.8
//
// Brief Users "manual"
// ..............................................................
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NearHspt
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BaseGuide : ContentPage
  {

    public BaseGuide(int arg001)
    {
      InitializeComponent();

      this.Title = "User Guide";
      BackgroundColor = Color.White;
    }

  }
}
