//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spottinglog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSighting
    {
        public int Sightingid { get; set; }
        public string Registration { get; set; }
        public string Airline { get; set; }
        public string AircraftType { get; set; }
        public string MSN { get; set; }
        public string PhotoCode { get; set; }
        public Nullable<int> SpottingTrip { get; set; }
        public string Notes { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}