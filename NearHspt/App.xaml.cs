// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: App
// Vers: 5.1.0.0
//
// The actual start of all data and control flows
// .............................................................
using NearHspt.AA_Utilities;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration; //= Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage;
using System;
using System.Net;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NearHspt
{
  public partial class App : Xamarin.Forms.Application
    {

    public static bool majorGEOerror;

    // Geo Location
    public static double deviceLatitude = 0.0;
    public static double deviceLongitude = 0.0;

    // ..................................................................................
    // Hospital "DB"
    public static string[,] hospitalsDB = new string[7200, 16];
    public static int hospitalsDBRowsCount = 0;
    public static int hospitalsDBColsCount = 0;
    public static double hospitalRange = 100.0;
    public static int[,] hospitalsInRange = new int[7200, 2];
    public static int hospitalsInRangeCount = 0;
    public static int hospitalsShownCount = 0;
    public static int selectedHospital = 0;

    public static string userSelectedAddress = "";
    // ..................................................................................

    #region Notification popup
    public static bool PopupAccepted = false;
    #endregion


    public static string AppName = "Near Hospital";
    public static string AppVersion = "5.1.0.0";
    public static string RegNum = "MH-UY-89887-IO";
    public static string RegWhen = "Jan-13-20";
    public static string RelDate = "Jan. 13 2021";


    public static double DisplayScreenWidth;                    // = 0f;
    public static double DisplayScreenHeight;                   // = 0f;
    public static double DisplayScaleFactor;                    // = 0f;
    public static double DisplayScaleMax;                       // = 0f;



    public App()
    {
      bool iB;
      InitializeComponent();

      //
      // Get all data into global (App. global) strings
      iB = FlatData.GetHospitalDB();
      //
      // Set the Kill-Permission-Repeater
      //
      Preferences.Set("manageRepeatgeoPermission", 0);
      MainPage = new AppShell();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }

        public bool PromptToConfirmExit
        {
            get
            {
                bool v = NewMethod(false);

                return false;
            }
        }

        private bool NewMethod(bool v)
        {
            throw new NotImplementedException();
        }
    }

    //    private bool NewMethod
    //    {
    //        get
    //        {
    //            Xamarin.Forms.NavigationPage MainPage = null;
    //            if (MainPage is ContentPage)
    //            {
    //                promptToConfirmExit = true;
    //            }

    //            else if (MainPage is Xamarin.Forms.NavigationPage detailNavigationPage)
    //            {
    //                promptToConfirmExit = detailNavigationPage.Navigation.NavigationStack.Count <= 1;
    //            }
    //            else if (MainPage is Xamarin.Forms.NavigationPage mainPage)
    //            {
    //                if (mainPage.CurrentPage is Xamarin.Forms.TabbedPage tabbedPage
    //                    && tabbedPage.CurrentPage is Xamarin.Forms.NavigationPage navigationPage)
    //                {
    //                    promptToConfirmExit = navigationPage.Navigation.NavigationStack.Count <= 1;
    //                }
    //                else
    //                {
    //                    promptToConfirmExit = mainPage.Navigation.NavigationStack.Count <= 1;
    //                }
    //            }
    //            else if (MainPage is Xamarin.Forms.TabbedPage tabbedPage
    //                && tabbedPage.CurrentPage is Xamarin.Forms.NavigationPage navigationPage)
    //            {
    //                promptToConfirmExit = navigationPage.Navigation.NavigationStack.Count <= 1;
    //            }

    //            return promptToConfirmExit;
    //        }
    //    }

    //    public bool IsToastExitConfirmation(bool value)
    //    {
    //        bool IsToastExitConfirmation = false;
    //        return Preferences.Get(nameof(IsToastExitConfirmation), false);
    //    }

    //    public void SetIsToastExitConfirmation(bool value)
    //    {
    //        bool IsToastExitConfirmation = false;
    //        Preferences.Set(nameof(IsToastExitConfirmation), value);
    //    }

    //    string nameof(object isToastExitConfirmation)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    string Nameof(object isToastExitConfirmation)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private object IsToastExitConfirmation()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

