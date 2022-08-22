using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spottinglog.Models;
using Spottinglog.DataAccess;
namespace Spottinglog.Controllers
{
    public class TripController : Controller
    {
        private SpottinglogEntities db = new SpottinglogEntities();
        // GET: Trip
        public ActionResult Index()
        {
            try
            {



                ViewBag.Country = new SelectList(DalSighting.GetInstance.GetCountry(), "Countryid", "Country");

                return View();
            }

            catch (Exception ex)
            {
                return View();

            }
        }

        public ActionResult TripList()
        {

            try
            {
                var user = (tblUser)Session["User"];
                return View(DalSighting.GetInstance.GetSpottingTrip(user));


            }

            catch (Exception ex)
            {

                return View();
            }
        }





        public JsonResult GetAirport(int state)
        {


            try

            {
                var Airport = DalSighting.GetInstance.GetAirport(state);
                var jsAirport = Json(Airport, JsonRequestBehavior.AllowGet);

                return jsAirport;
            }
            catch (Exception ex)
            {
               
                return null;


            }


        }

        // GET: Trip/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trip/Create
        [HttpPost]
        public ActionResult Create(tblSpottingTrip collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var user = (tblUser)Session["User"];
                    collection.TripDescription = collection.Airport + "-" + collection.DateofTrip;
                    collection.UserID = user.Userid;
                    db.tblSpottingTrips.Add(collection);
                    db.SaveChanges();
                    // return RedirectToAction("Index");

                }
                return RedirectToAction("TripList");

            }
            catch
            {
                return View();
            }
        }

        // GET: Trip/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {

                ViewBag.Country = new SelectList(DalSighting.GetInstance.GetCountry(), "Countryid", "Country");
                var tblSpottingTrip = db.tblSpottingTrips.Find(id);
                return View(tblSpottingTrip);

            }

            catch
            {
                return View();
            }

        }

        // POST: Trip/Edit/5
        [HttpPost]
        public ActionResult Edit(tblSpottingTrip collection)
        {
            try
            {
                // TODO: Add update logic here
                DalSighting.GetInstance.UpdatetblSpottingTrip(collection);
                return RedirectToAction("TripList");

            }
            catch
            {
                return View();
            }
        }

        // GET: Trip/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                var trip = db.tblSpottingTrips.Find(id);
                db.tblSpottingTrips.Remove(trip);
                db.SaveChanges();
                return RedirectToAction("TripList", "Trip");
            }

            catch (Exception ex)
            {
                return RedirectToAction("TripList", "Trip");
            }
        }

        // POST: Trip/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
