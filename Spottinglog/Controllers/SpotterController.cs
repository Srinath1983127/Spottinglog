using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spottinglog.DataAccess;
namespace Spottinglog.Controllers
{
    public class SpotterController : Controller
    {
        // GET: Spotter
        public ActionResult Index()
        {
            try
            {
               
                return View(DalSighting.GetInstance.GetsSpotters());
            }

            catch (Exception ex)
            {

                return View();
            }
        }

        // GET: Spotter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Spotter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spotter/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Spotter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Spotter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Spotter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Spotter/Delete/5
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
