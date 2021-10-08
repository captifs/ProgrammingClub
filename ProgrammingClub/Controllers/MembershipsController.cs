using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub.Controllers
{
    public class MembershipsController : Controller
    {
        // GET: Memberships
        public ActionResult Index()
        {
            return View();
        }

        // GET: Memberships/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memberships/Create
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

        // GET: Memberships/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Memberships/Edit/5
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

        // GET: Memberships/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Memberships/Delete/5
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
