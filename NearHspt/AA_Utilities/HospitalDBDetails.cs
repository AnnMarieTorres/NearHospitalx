// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: HospitalDBDetails
// Vers: 5.1.0.0
//
// Fields for the 'Hospital' DB
// .............................................................
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NearHspt.Models;

namespace NearHspt.AA_Utilities
{
  public class HospitalDBDetails
  {
    private ObservableCollection<HospitalDBInfo> hospitalInfo;
    public ObservableCollection<HospitalDBInfo> HospitalInfoCollection
    {
      get { return hospitalInfo; }
      set { this.hospitalInfo = value; }
    }

    public static List<rootHospital_DB_List> List100 { get; private set; }


    

    public HospitalDBDetails()
    {
      hospitalInfo = new ObservableCollection<HospitalDBInfo>();
      //grb//this.GenerateOrders();
    }

    public static void GenerateOrders()
    {

      List100 = new List<rootHospital_DB_List>();

      //////List100.Add(new rootHospital_DB_List
      //////{
      //////  HospitalName = "CENTRA STATE MEDICAL CENTER",
      //////  HospitalBedcount = "1234",
      //////  HospitalDistance = "999.33"
      //////});



      // .........................................................................................
      // 1. we have a list of hospital pointers distances (from FindHospital"
      // 2. we will create a list (setList6) of hospitals, (distance, Name), keyed by distance
      // .........................................................................................
      //ObservableCollection<HospitalListmach> listSource6s = new ObservableCollection<HospitalListmach>();


      string[] setList6 = new string[App.hospitalsInRangeCount];
      int inow;
      int newIndex;
      string strMilage;
      string strMiles;
      string strBeds;
      string strBedCount;
      string strName;
      App.hospitalsShownCount = 0;


      // convert hospitalRange to int and multiply by 100 to capture last two digits ( 100.00 --> 10000)
      // The hospitalsInRange[,] array has mileage converted to int * 100 also.
      int icheckdis = Convert.ToInt32((App.hospitalRange) * 100.00);
      for (inow = 0; inow < App.hospitalsInRangeCount; inow++)
      {
        if ((Convert.ToInt32(App.hospitalsInRange[inow, 1])) < icheckdis)
        {
          newIndex = App.hospitalsInRange[inow, 0];
          strMilage = (((Convert.ToDouble(App.hospitalsInRange[inow, 1])) / 100.0)).ToString();
          strBeds = App.hospitalsDB[newIndex, 13];
          if (strBeds == "") strBeds = "N/R";
          strName = App.hospitalsDB[newIndex, 0];
          //
          // ?????????????????????????????????????????????????????????????????????????????????????????

          string tempaa = strMilage.ToString();
          if (tempaa.IndexOf(".") == -1) tempaa = tempaa + ".00";
          if (tempaa.IndexOf(".") == tempaa.Length-2) tempaa = tempaa + "0";
          if (tempaa.Length == 4) tempaa = "  " + tempaa;
          if (tempaa.Length ==5) tempaa = " " + tempaa;

          if (strBeds == "N/R")
          {
            strBeds = "  xxx";
          }
          else
          {
            if (strBeds.Length == 1) strBeds = "    " + strBeds;
            if (strBeds.Length == 2) strBeds = "   " + strBeds;
            if (strBeds.Length == 3) strBeds = "  " + strBeds;
          }
          // ?????????????????????????????????????????????????????????????????????????????????????????
          //
          //                      7.32                    399              CentraState
          setList6[inow] = tempaa + "^" + strBeds + "^" + strName;
          //}
        }
        else
        {
          //
          // the list is from shortest to longest distance
          // the first time the listed mileage is above the requested, we can leave the for loop
          break;
        }
      }


      //ObservableCollection<HospitalListmach> listSource6 = new ObservableCollection<HospitalListmach>();



      int know = 0;
      for (know = 0; know < App.hospitalsInRangeCount; know++)
      {

        newIndex = App.hospitalsInRange[know, 0];
        strMilage = (((Convert.ToDouble(App.hospitalsInRange[know, 1])) / 100.0)).ToString();
        strBeds = App.hospitalsDB[newIndex, 13];
        if (strBeds == "") strBeds = "N/R";
        strName = App.hospitalsDB[newIndex, 0];
        //                      7.32                    399              CentraState
        //setList6[inow] = strMilage.ToString() + "^" + strBeds + "^" + strName;



        // strTemp[0] "7.12"   [1] "399"    [2] "CentraState"
        //string[] strTemp = setList6[know].Split('^');
        strMiles = strMilage.ToString();    // strTemp[0];
        strBedCount = strBeds;              // strTemp[1];
                                            //strName = strName;                  // strTemp[2];

        //string temp100 = strName + "\n" + strmiles;
        //
        // "Bayshore Community Hospital\n   1.7 miles   181 beds"
        //listSource6.Add(new HospitalListmach { DisplayName = temp100 }); // setList6[know] });
        //

        string tempaa = strMiles.ToString();
        if (tempaa.IndexOf(".") == -1) tempaa = tempaa + ".00";
        if (tempaa.IndexOf(".") == tempaa.Length - 2) tempaa = tempaa + "0";
        if (tempaa.Length == 4) tempaa = "  " + tempaa;
        if (tempaa.Length == 5) tempaa = " " + tempaa;

        if (strBedCount == "N/R")
        {
          strBedCount = "  xxx";
        }
        else
        {
          if (strBedCount.Length == 1) strBedCount = "    " + strBedCount;
          if (strBedCount.Length == 2) strBedCount = "   " + strBedCount;
          if (strBedCount.Length == 3) strBedCount = "  " + strBedCount;
        }

        //
        //grb//hospitalInfo.Add(new HospitalDBInfo(tempaa, strBedCount, strName ));

        List100.Add(new rootHospital_DB_List
        {
          HospitalName = strName,
          HospitalBedcount = strBedCount,
          HospitalDistance = tempaa
        });
      }
    }


  }
}