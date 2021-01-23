// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Call_911
// Vers: 5.1.0.0
//
// Call 911 details routine
// .............................................................
using System;
using System.Linq;
using Xamarin.Forms;
using NearHspt.Data;


namespace NearHspt.Views
{
    [QueryProperty("Name", "name")]
    public partial class Single002DetailPage : ContentPage
    {
        public string Name
        {
            set
            {
                BindingContext = Single02Data.Single02_Equipment.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
            }
        }

        public Single002DetailPage()
        {
            InitializeComponent();
        }
    }
}
