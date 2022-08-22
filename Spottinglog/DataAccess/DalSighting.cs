using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spottinglog.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Spottinglog.DataAccess
{
    
    public class DalSighting
    {
        private SpottinglogEntities db = new SpottinglogEntities();
        private static readonly object DocLock = new object();
        private static DalSighting _instance;

        private DalSighting()
        {
        }

        public static DalSighting GetInstance
        {
            get
            {
                lock (DocLock)
                {
                    return _instance ?? (_instance = new DalSighting());
                }
            }
        }

        public IEnumerable<SightingList> Getslightingvw(tblUser user)
        {
            try

            {

               
                var slightingvw = new List<SightingList>();
                var query = from c in db.SightingLists
                            where c.UserID == user.Userid
                            select c;
                slightingvw = query.ToList<SightingList>();
                return slightingvw;
                
            }
            catch (Exception ex)
            {
               
                return null;


            }




        }

        public IEnumerable<SightingList> GetsSpotters()
        {
            try

            {


                var slightingvw = new List<SightingList>();
                var query = from c in db.SightingLists

                            select c;
                slightingvw = query.ToList<SightingList>();
                return slightingvw;

            }
            catch (Exception ex)
            {

                return null;


            }




        }






        public IEnumerable<tblSpottingTrip> GetSpottingTrip(tblUser user)
        {
            try

            {


                var tblSpottingTrip = new List<tblSpottingTrip>();
                var query = from c in db.tblSpottingTrips
                            where c.UserID == user.Userid
                            select c;
                tblSpottingTrip = query.ToList<tblSpottingTrip>();
                return tblSpottingTrip;

            }
            catch (Exception ex)
            {

                return null;


            }




        }

        public IEnumerable<tblSpottingTrip> GetSpottingTripe()
        {
            try

            {
                var SpottingTrip = new List<tblSpottingTrip>();
                var query = from c in db.tblSpottingTrips
                            select c;
                SpottingTrip = query.ToList<tblSpottingTrip>();
                return SpottingTrip;

            }
            catch (Exception ex)
            {
                
                return null;


            }




        }

        public IEnumerable<tblCountry> GetCountry()
        {
            try

            {
                var Country = new List<tblCountry>();
                var query = from c in db.tblCountries
                            select c;
                Country = query.ToList<tblCountry>();
                return Country;

            }
            catch (Exception ex)
            {

                return null;


            }




        }

        




        public List<tblAirport> GetAirport(int Countryid)
        {
            try

            {
                var Airport = new List<tblAirport>();
                var query = from c in db.tblAirports
                            where c.Countryid == Countryid
                            select c;
                Airport = query.ToList<tblAirport>();
                return Airport;
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }

        public bool Updateslighting(tblSighting Sighting)
        {
            try
            {
                var oSighting = new tblSighting();
                oSighting = db.tblSightings.Find(Sighting.Sightingid);

                oSighting.Registration = Sighting.Registration;
                oSighting.Airline = Sighting.Airline;
                oSighting.AircraftType = Sighting.AircraftType;
                oSighting.MSN = Sighting.MSN;
                oSighting.PhotoCode = Sighting.PhotoCode;
                oSighting.SpottingTrip = Sighting.SpottingTrip;
                oSighting.Notes = Sighting.Notes;
                oSighting.UserID = Sighting.UserID;
                db.Entry(oSighting).State = EntityState.Modified;
                db.SaveChanges();
           
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public bool UpdatetblSpottingTrip(tblSpottingTrip Trips)
        {
            try
            {
                var oTrips = new tblSpottingTrip();
                oTrips = db.tblSpottingTrips.Find(Trips.TripId);

                oTrips.Country = Trips.Country;
                oTrips.Airport = Trips.Airport;
                oTrips.DateofTrip = Trips.DateofTrip;
                oTrips.Comments = Trips.Comments;
                oTrips.UserID = Trips.UserID;
                oTrips.TripDescription = Trips.Airport + "-" + Trips.DateofTrip;
               
                db.Entry(oTrips).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}