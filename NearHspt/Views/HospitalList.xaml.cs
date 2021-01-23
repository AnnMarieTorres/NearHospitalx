﻿// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: HospitalAll
// Vers: 5.1.0.0
//
// Contains list of  all nearby (100 miles) hospitals
// .............................................................
using System;
using NearHspt.AA_Utilities;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NearHspt.Models;

namespace NearHspt.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HospitalList : ContentPage
  {
    public IList<rootHospital_DB_List> List100 { get; private set; }
    public HospitalList()
    {
      InitializeComponent();

      #region intro stuff
      this.Title = "Near Hospitals/ER's";
      BackgroundColor = Color.Black; // WhiteSmoke;
      Opacity = 0.9;

      #endregion

      //
      // create the list of hospitals (10 nearby, or first 100 from db)
      bool ibb = createHospitalList();

      BindingContext = this;
    }


    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // All private functions
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // =======================================================================
    // On appearing:
    //
    // =======================================================================
    protected override void OnAppearing()
    {
      base.OnAppearing();
    }


    // =======================================================================
    // On Disappearing
    //
    // =======================================================================
    protected override void OnDisappearing()
    {
      //System.Timers.Timer baseTimer = new System.Timers.Timer();
      //MainPage.baseTimer.Stop();
    }

    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    // =======================================================================
    // createHospitalList
    //
    // =======================================================================
    private bool createHospitalList()
    {
      bool ib = true;

      //grb//HospitalDBDetails.GenerateOrders();



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
          if (tempaa.IndexOf(".") == -1)
          {
            tempaa += ".00";
          }

          if (tempaa.IndexOf(".") == tempaa.Length - 2) tempaa += "0";
          if (tempaa.Length == 4)
          {
            tempaa = "  " + tempaa;
          }

          if (tempaa.Length == 5) tempaa = " " + tempaa;

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
        if (tempaa.IndexOf(".") == -1) tempaa += ".00";
        if (tempaa.IndexOf(".") == tempaa.Length - 2) tempaa += "0";
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
















        #region detail items

        ////////////////////////////////////////////////////////////List100 = new List<rootHospital_DB_List>();

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "CENTRA STATE MEDICAL CENTER",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "RIVERVIEW MEDICAL CENTER",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "STATEN ISLEND UNIVERSITY HOSPITAL",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mountkkkkkkkkkkkkkkkllllllll 100 and 500 and 600 and 700 and 800 and 900",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});
        ////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        ////////////////////////////////////////////////////////////{
        ////////////////////////////////////////////////////////////  HospitalName = "Mount 101",
        ////////////////////////////////////////////////////////////  HospitalBedcount = "1234",
        ////////////////////////////////////////////////////////////  HospitalDistance = "999.33"
        ////////////////////////////////////////////////////////////});

        //////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        //////////////////////////////////////////////////////////////{
        //////////////////////////////////////////////////////////////  HospitalName = "Thomas's Langur",
        //////////////////////////////////////////////////////////////  HospitalBedcount = "Indonesia",
        //////////////////////////////////////////////////////////////  HospitalDistance = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Thomas%27s_langur_Presbytis_thomasi.jpg/142px-Thomas%27s_langur_Presbytis_thomasi.jpg"
        //////////////////////////////////////////////////////////////});

        //////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        //////////////////////////////////////////////////////////////{
        //////////////////////////////////////////////////////////////  HospitalName = "Purple-faced Langur",
        //////////////////////////////////////////////////////////////  HospitalBedcount = "Sri Lanka",
        //////////////////////////////////////////////////////////////  HospitalDistance = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Semnopithèque_blanchâtre_mâle.JPG/192px-Semnopithèque_blanchâtre_mâle.JPG"
        //////////////////////////////////////////////////////////////});

        //////////////////////////////////////////////////////////////List100.Add(new rootHospital_DB_List
        //////////////////////////////////////////////////////////////{
        //////////////////////////////////////////////////////////////  HospitalName = "Gelada",
        //////////////////////////////////////////////////////////////  HospitalBedcount = "Ethiopia",
        //////////////////////////////////////////////////////////////  HospitalDistance = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Gelada-Pavian.jpg/320px-Gelada-Pavian.jpg"
        //////////////////////////////////////////////////////////////});

        #endregion

        return ib;
    }


    void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      rootHospital_DB_List selectedItem = e.SelectedItem as rootHospital_DB_List;

    }

    async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
      rootHospital_DB_List tappedItem = e.Item as rootHospital_DB_List;


      string selName = tappedItem.HospitalName;  //grb// selectedBatchRecorda.HospitalName.ToString();

      //
      // get a pointer into the full record, residing
      // on the "all hospitals in 100-hit group" file
      //
      for (int ii = 0; ii < App.hospitalsInRangeCount; ii++)
      {
        if (App.hospitalsDB[App.hospitalsInRange[ii, 0], 0] == selName)
        {
          App.selectedHospital = App.hospitalsInRange[ii, 0];
          break;
        }
      }

      string searchStr = "https://www.google.com/search?q=%22";

      //App.hospitalsDB[App.selectedHospital, 0] = "CENTRA STATE MEDICAL CENTER";
      //App.hospitalsDB[App.selectedHospital, 3] = "Freehold";
      //App.hospitalsDB[App.selectedHospital, 4] = "NJ";


      searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
      searchStr += "%22";

      await Browser.OpenAsync(searchStr, BrowserLaunchMode.SystemPreferred);




    }


    ////////////////////#region Data Grid Selection

    ////////////////////// ----------------------------------------------------------------------------------
    ////////////////////// Grid selection, distance, bed count, name
    ////////////////////// ----------------------------------------------------------------------------------
    ////////////////////private async void dataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
    ////////////////////{
    ////////////////////  HospitalDBInfo selectedBatchRecorda = (e.AddedItems[0] as HospitalDBInfo);
    ////////////////////  string selName = selectedBatchRecorda.HospitalName.ToString();

    ////////////////////  //
    ////////////////////  // get a pointer into the full record, residing
    ////////////////////  // on the "all hospitals in 100-hit group" file
    ////////////////////  //
    ////////////////////  for (int ii = 0; ii < App.hospitalsInRangeCount; ii++)
    ////////////////////  {
    ////////////////////    if (App.hospitalsDB[App.hospitalsInRange[ii, 0], 0] == selName)
    ////////////////////    {
    ////////////////////      App.selectedHospital = App.hospitalsInRange[ii, 0];
    ////////////////////      break;
    ////////////////////    }
    ////////////////////  }

    ////////////////////  string searchStr = "https://www.google.com/search?q=%22";
    ////////////////////  searchStr = searchStr + App.hospitalsDB[App.selectedHospital, 0] + "," + App.hospitalsDB[App.selectedHospital, 3] + "," + App.hospitalsDB[App.selectedHospital, 4];
    ////////////////////  searchStr = searchStr + "%22";

    ////////////////////  await Browser.OpenAsync(searchStr, BrowserLaunchMode.SystemPreferred);

    ////////////////////}

    ////////////////////#endregion


    ////////////////////public class HospitalListmach
    ////////////////////{
    ////////////////////  public string DisplayName { get; set; }
    ////////////////////}

  }
}
