// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: Root Hospital DB List
// Vers: 5.1.0.0
//
// Low-Level IO routines
// .............................................................
using System;
using System.Collections.Generic;
using System.Text;

namespace NearHspt
{
  public class rootHospital_DB_List
  {
    public string HospitalName { get; set; }
    public string HospitalBedcount { get; set; }
    public string HospitalDistance { get; set; }

    public override string ToString()
    {
      return HospitalName;
    }
  }
}
