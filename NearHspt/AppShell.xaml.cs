using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
//using NearHspt.Data;
using NearHspt.Views;

namespace NearHspt
{
  public partial class AppShell : Shell
  {
    Random rand = new Random();
    Dictionary<string, Type> routes = new Dictionary<string, Type>();
    public Dictionary<string, Type> Routes { get { return routes; } }

    public AppShell()
    {
      InitializeComponent();
      RegisterRoutes();
      BindingContext = this;
    }

    void RegisterRoutes()
    {
      //grb//routes.Add("single001_route_details", typeof(Single001DetailPage));
      //routes.Add("single003_route_details", typeof(Single003DetailPage));
      //routes.Add("single002_route_details", typeof(Single002DetailPage));

      foreach (var item in routes)
      {
        Routing.RegisterRoute(item.Key, item.Value);
      }
    }


    void OnNavigating(object sender, ShellNavigatingEventArgs e)
    {
      //Cancel any back navigation
      if (e.Source == ShellNavigationSource.Pop)
      {
        e.Cancel();
      }
    }

    void OnNavigated(object sender, ShellNavigatedEventArgs e)
    {
    }
  }
}
