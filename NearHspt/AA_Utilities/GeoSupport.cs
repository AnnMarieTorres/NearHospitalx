// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: GeoSupport
// Vers: 5.1.0.0
//
// Low-level geo routines
// .............................................................
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NearHspt.AA_Utilities
{
  class GeoSupport
  {

    #region Dev Location


    // ===================================================================================================
    // Get plain latitude / longitude values
    //
    // ===================================================================================================
    public static async Task GetLatLongAsync()
    {
      App.majorGEOerror = false;
      try
      {
        var georequest = new GeolocationRequest(GeolocationAccuracy.Best);
        Location llx = await Geolocation.GetLocationAsync(georequest);

        App.deviceLatitude = llx.Latitude;
        App.deviceLongitude = llx.Longitude;
        if (Convert.ToInt32(App.deviceLatitude * 100.0) == 0) App.majorGEOerror = true;
      }
      catch (Exception ex)
      {
        _ = ex.ToString();
        App.deviceLatitude = 0.0F;
        App.deviceLongitude = 0.0F;
        App.majorGEOerror = true;
      }
    }


    // ===================================================================================================
    // Get plain latitude / longitude values
    //
    // ===================================================================================================
    public static async Task GetLatitude_LongitudeAsync()
    {
      App.majorGEOerror = false;
      string addressLabel = "";

      try
      {
        var georequest = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
        //grb//cts = new CancellationTokenSource();
        Location llx = await Geolocation.GetLocationAsync(georequest);

        App.deviceLatitude = llx.Latitude;
        App.deviceLongitude = llx.Longitude;
        if (Convert.ToInt32(App.deviceLatitude * 100.0) == 0) App.majorGEOerror = true;
      }
      catch (Exception ex)
      {
        _ = ex.ToString();
        App.deviceLatitude = 0.0F;
        App.deviceLongitude = 0.0F;
        App.majorGEOerror = true;
      }

      //
      //
      //

      try
      {
        //
        // Get / use Latitude, Longitude. Post address.
        //
        var manyPlacemarks = await Geocoding.GetPlacemarksAsync(App.deviceLatitude, App.deviceLongitude);
        var placemark = manyPlacemarks?.FirstOrDefault();
        if (placemark != null)
        {
          addressLabel = "  " +
            placemark.FeatureName + " " +
            placemark.Thoroughfare + ",  \n" + "  " +
            placemark.Locality + "  \n" + "  " +
            placemark.AdminArea + ", " + placemark.CountryCode + "  " + placemark.PostalCode + "  ";
        }
      }
      catch (Exception ex)
      {
        _ = ex.ToString();
        addressLabel = " Problem finding GPS position";
        App.majorGEOerror = true;
      }

      Alles.lbMyAddressGlobal = addressLabel;
    }



    // ===================================================================================================
    // Get geo location, and work with it
    //
    // ===================================================================================================
    public static void Create_NearDBIndex()
    {
      App.majorGEOerror = false;
      try
      {
        FlatData.Load_HospitalsInRage(App.deviceLatitude, App.deviceLongitude);
      }
      catch (Exception ex)
      {
        _ = ex.ToString();
        App.majorGEOerror = true;
      }
    }


    // ===================================================================================================
    // Get geo location, set address display, 
    //    show nearest hospital in button, 
    //    show all-other count in next button
    //
    // ===================================================================================================
    public static async Task SetAddressbtContents(Button btdisplayAllHospitals, Button nearestHospital, Label PrimlblDisplayAddress)
    {

      try
      {
        //
        // Get / use Latitude, Longitude. Post address.
        //
        var manyPlacemarks = await Geocoding.GetPlacemarksAsync(App.deviceLatitude, App.deviceLongitude);
        var placemark = manyPlacemarks?.FirstOrDefault();
        if (placemark != null)
        {
          PrimlblDisplayAddress.Text = "  " + 
            placemark.FeatureName + " " + 
            placemark.Thoroughfare + ",  \n" + "  " + 
            placemark.Locality + "  \n" + "  " + 
            placemark.AdminArea + ", " + placemark.CountryCode + "  " + placemark.PostalCode + "  ";
        }
        //
        // With current 100-hospital list, Show Actual Nearest Hospital
        //
        nearestHospital.Text=ShowNearestHospital();
        //
        // Post 100 miles / 100 count to button.
        //
        if (App.hospitalsInRangeCount == -1)
        {
          App.hospitalsInRangeCount = 0;
          btdisplayAllHospitals.Text = " No additional Hospitals";
        }
        else
        {
          btdisplayAllHospitals.Text = " " + App.hospitalsInRangeCount.ToString() + " more Hospitals";
        }

      }
      catch (Exception ex)
      {
        _ = ex.ToString();
        PrimlblDisplayAddress.Text = " Problem finding GPS position";
        App.majorGEOerror = true;
      }
    }


    // ===================================================================================================
    // Show nearest hospital (distance, name)
    //
    // ===================================================================================================
    public static string ShowNearestHospital()
    {
      string nnReturn;
      if (App.hospitalsInRangeCount == 0)
      {
        nnReturn = " No near Hospital found yet.";
        return nnReturn;
      }
      if (App.hospitalsInRangeCount == -1)
      {
        nnReturn = " Address Coordinates not inside the USA";
      }
      else
      {
        nnReturn = "  " + 
          Convert.ToDouble(App.hospitalsInRange[0, 1] / 100.00).ToString() + " miles  --  " + 
          App.hospitalsDB[App.hospitalsInRange[0, 0], 0] + "     more ...";
      }
      return nnReturn;
    }


    // ===================================================================================================
    // Display Google Map by address from an image
    // 
    // ===================================================================================================
    public static async Task ActualAddressMap()
    {
      try
      {

        //
        // get hospital
        //
        int hloc = App.hospitalsInRange[0, 0];
        double hLat = Convert.ToDouble(App.hospitalsDB[hloc, 8]);
        double hLong = Convert.ToDouble(App.hospitalsDB[hloc, 9]);
        var location = new Location(hLat, hLong);
        //var myGEOlocation=new Location(App.deviceLatitude, App.deviceLongitude);
        var options = new MapLaunchOptions { Name = "My Address", NavigationMode = NavigationMode.Driving };

        await Map.OpenAsync(location, options);

      }
      catch (Exception ex)
      {
        _ = ex.Message.ToString();
      }

    }


    // ===================================================================================================
    // Lating Class
    // ===================================================================================================
    public class LatLng
    {
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public LatLng(double latin, double lngin)
      {
        this.Latitude = latin;
        this.Longitude = lngin;
      }
    }

    #endregion


  }
}