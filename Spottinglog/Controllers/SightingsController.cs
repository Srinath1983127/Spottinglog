using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spottinglog.Models;
using Spottinglog.DataAccess;
using System.IO;

namespace Spottinglog.Controllers
{
    public class SightingsController : Controller
    {

        private SpottinglogEntities db = new SpottinglogEntities();
        // GET: Sightings
        public ActionResult Index()
        {
            try
            {
                ///var user = (SystemUser)Session["User"];
                // user.ID = 1;
                ViewBag.SpottingTripe = new SelectList(DalSighting.GetInstance.GetSpottingTripe(), "TripId", "TripDescription");

                // return View(db.tblSightings.ToList());
                return View();
            }

            catch (Exception ex)
            {

                return View();
            }
        }



        public ActionResult Index1()
        {
            try
            {
                ///var user = (SystemUser)Session["User"];
                // user.ID = 1;
                ViewBag.SpottingTripe = new SelectList(DalSighting.GetInstance.GetSpottingTripe(), "TripId", "TripDescription");

                // return View(db.tblSightings.ToList());
                return View();
            }

            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Sightings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sightings/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.SpottingTripe = new SelectList(DalSighting.GetInstance.GetSpottingTripe(), "TripId", "TripDescription");

               // return View(db.tblSightings.ToList());
               return View();
            }

            catch (Exception ex)
            {

                return View();

            }




            
        }

        // POST: Sightings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblSighting collection, HttpPostedFileBase PhotoCode)
        {

            try
            {



                if (ModelState.IsValid)
                {
                    var user = (tblUser)Session["User"];



                    var path = Server.MapPath("~/Spottinglmg/") + PhotoCode.FileName;
                    PhotoCode.SaveAs(path);
                    collection.PhotoCode = PhotoCode.FileName;
                    collection.UserID = user.Userid;
                    db.tblSightings.Add(collection);
                    db.SaveChanges();
                    //return RedirectToAction("Index");

                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {
                    ViewBag.SpottingTripe = new SelectList(DalSighting.GetInstance.GetSpottingTripe(), "TripId", "TripDescription");

                    // return RedirectToAction("Index", collection);
                    return View(collection);
                }
            }
            catch (Exception ex)
            {

                return View(collection);
            }

        }



        public ActionResult CreateSighting(tblSighting collection)
        {
            if (ModelState.IsValid)
            {
                db.tblSightings.Add(collection);
                db.SaveChanges();
                // return RedirectToAction("Index");

            }
          
         return RedirectToAction("Index");
        }

        // GET: Sightings/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                ViewBag.SpottingTripe = new SelectList(DalSighting.GetInstance.GetSpottingTripe(), "TripId", "TripDescription");
                var Sighting = db.tblSightings.Find(id);

                return View(Sighting);
            }
            catch (Exception ex)

            {
                return View();
            }
        }

        // POST: Sightings/Edit/5
        [HttpPost]
        public ActionResult Edit( tblSighting collection, HttpPostedFileBase PhotoCode)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    
                     var path = Server.MapPath("~/Spottinglmg/") + PhotoCode.FileName;
                     PhotoCode.SaveAs(path);
                   
                    collection.PhotoCode = PhotoCode.FileName;
                    DalSighting.GetInstance.Updateslighting(collection);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sightings/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                var Sightings = db.tblSightings.Find(id);
                db.tblSightings.Remove(Sightings);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {

                return View();
            }


        }

        // POST: Sightings/Delete/5
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
