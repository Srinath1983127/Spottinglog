﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SpottinglogEntities : DbContext
    {
        public SpottinglogEntities()
            : base("name=SpottinglogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCountry> tblCountries { get; set; }
        public virtual DbSet<tblSighting> tblSightings { get; set; }
        public virtual DbSet<tblSpottingTrip> tblSpottingTrips { get; set; }
        public virtual DbSet<tblAirport> tblAirports { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<SightingList> SightingLists { get; set; }
    }
}
