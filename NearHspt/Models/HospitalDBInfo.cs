// ..............................................................
// Copyright @ 2021  CNG Internet Software, LLC
//
// Project: Nearby Hospital / ER
//
// Name: HospitalDBInfo
// Vers: 5.1.0.0
//
// Hospital DB Field details
// .............................................................
using System;
using System.Collections.Generic;
using System.Text;

namespace NearHspt.Models
{
  public class HospitalDBInfo
  {
    public string hospitalDistance;
    public string hospitalBedcount;
    public string hospitalName;


    public string HospitalDistance
    {
      get { return hospitalDistance; }
      set { this.hospitalDistance = value; }
    }
    public string HospitalBedcount
    {
      get { return hospitalBedcount; }
      set { this.hospitalBedcount = value; }
    }
    public string HospitalName
    {
      get { return this.hospitalName; }
      set { this.hospitalName = value; }
    }


    public HospitalDBInfo(string hospitalDistance, string hospitalBedcount, string hospitalName)
    {
      this.HospitalDistance = hospitalDistance;
      this.HospitalBedcount = hospitalBedcount;
      this.HospitalName = hospitalName;
    }
  }
}

