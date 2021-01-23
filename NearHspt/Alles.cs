// ..............................................................
// Copyright @ 2020  CNG Internet Software, LLC.
//
// Project: Silence Mobile Phone in designated 'Silent Area'
//
// Name: Alles
// Vers: 3.1.0.4
//
// Global class, variables
// .............................................................
using System;
//grb//using NearHspt.Model;


namespace NearHspt
{
  public class Alles
  {

    #region Language material

    public static string CLanguage = "en";

    #endregion

    #region Database Material

    // Database name
    public const string dbname100 = "NearHspt002.db3";
    // SQLite
    //grb//public static DoNotRingDB database;

    public static int toManageRules = 0;

    #endregion


    public static int ReadyAndActive = 0;

    public static string lbMyAddressGlobal;

    //public new Alles.ContainActies[1,1]

    public static TimeSpan DNDDuration;
    public static string stDNDDUration;

    public static string[] backgrdReady = new string[100];        // ready / inactive
    public static double[] backgrdLat = new double[100];          // 40.234567
    public static double[] backgrdLong = new double[100];         // -78.987654
    public static int[] backgrdCircle = new int[100];             // 123
    public static int DBcnt = 0;                                  // 1, 4, 6, ..

    private static bool _backgroundReady;
    public static bool backgroundReady
    {
      get { return _backgroundReady; }
      set { _backgroundReady = value; }
    }


    private static bool _beepAllowed;
    public static bool BeepAllowed
    {
      get { return _beepAllowed; }
      set { _beepAllowed = value; }
    }


    #region Notification popup
    public static bool PopupAccepted = false;
    public static bool popupmsg_001;
    #endregion

    #region geo location, geo process details

    private static bool _majorGEOerror;
    public static bool majorGEOerror
    {
      get { return _majorGEOerror; }
      set { _majorGEOerror = value; }
    }




    private static bool _havePermissions;
    public static bool HavePermissions
    {
      get { return _havePermissions; }
      set { _havePermissions = value; }
    }




    private static double _device_Latitude;
    public static double device_Latitude
    {
      get { return _device_Latitude; }
      set { _device_Latitude = value; }
    }



    private static double _device_Longitude;
    public static double device_Longitude
    {
      get { return _device_Longitude; }
      set { _device_Longitude = value; }
    }



    private static double _device_Accuracy;
    public static double device_Accuracy
    {
      get { return _device_Accuracy; }
      set { _device_Accuracy = value; }
    }

    #endregion


    public readonly static string AppName = "Near Hospital Template";
    public readonly static string AppVersion = "5.1.0.0";
    public readonly static string RegNum = "YU-MKU-665-488";
    public readonly static string RegWhen = "Jan-13-2021";
    public readonly static string RelDate = "Jan-13-2021";


    //public static double ScreenWidth;        // Width (in pixels)
    //public static double ScreenHeight;       // Height (in pixels)


    private static double _screenWidth;
    public static double ScreenWidth
    {
      get { return _screenWidth; }
      set { _screenWidth = value; }
    }

    private static double _screenHeight;
    public static double ScreenHeight
    {
      get { return _screenHeight; }
      set { _screenHeight = value; }
    }


    #region "Result.cs" variables

    // if a share-note starts with "WD" (With Data), its a 
    // special share out or "Result" and carries some data too.
    public static string shareLabelDotText = "WD";


    private static double _deep;
    public static double Deep
    {
      get { return _deep; }
      set { _deep = value; }
    }

    private static double _aok;
    public static double AOK
    {
      get { return _aok; }
      set { _aok = value; }
    }

    private static double _shallow;
    public static double Shallow
    {
      get { return _shallow; }
      set { _shallow = value; }
    }

    private static double _percentnow;
    public static double Percentnow
    {
      get { return _percentnow; }
      set { _percentnow = value; }
    }

    private static double _percentKeep;
    public static double PercentKeep
    {
      get { return _percentKeep; }
      set { _percentKeep = value; }
    }

    private static string _datecpr;
    public static string Datecpr
    {
      get { return _datecpr; }
      set { _datecpr = value; }
    }

    private static string _timecpr;
    public static string Timecpr
    {
      get { return _timecpr; }
      set { _timecpr = value; }
    }

    private static string _datecprKeep;
    public static string DatecprKeep
    {
      get { return _datecprKeep; }
      set { _datecprKeep = value; }
    }

    private static string _timecprKeep;
    public static string TimecprKeep
    {
      get { return _timecprKeep; }
      set { _timecprKeep = value; }
    }

    #endregion


  }
}
