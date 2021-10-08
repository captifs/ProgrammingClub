using ProgrammingClub.Models;
using ProgrammingClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub.Controllers
{
    public class AnnouncementsController : Controller
    {
        private AnnouncementRepository announcementRepository = new AnnouncementRepository();
        // GET: Announcements
        public ActionResult Index()
        {
            List<AnnouncementModel> announcements = announcementRepository.GetAllAnouncements();
            return View("Index", announcements);
        }

        // GET: Announcements/Details/5
        public ActionResult Details(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
       
            return View("Details",announcementModel);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: Announcements/Create
       [Authorize(Roles = "User, Admin ")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.InsertAnnouncement(announcementModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: Announcements/Edit/5
        public ActionResult Edit(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("EditAnnouncement",announcementModel);
        }

        // POST: Announcements/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AnnouncementModel announcementModel = new AnnouncementModel();
                UpdateModel(announcementModel);
                announcementRepository.UpdateAnouncement(announcementModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAnnouncement");
            }
        }

        // GET: Announcements/Delete/5
        public ActionResult Delete(Guid id)
        {
            AnnouncementModel announcementModel = announcementRepository.GetAnnouncementById(id);
            return View("Delete", announcementModel);
      
        }

        // POST: Announcements/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                announcementRepository.DeleteAnouncement(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
