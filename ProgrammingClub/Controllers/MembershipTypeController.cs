using ProgrammingClub.Models;
using ProgrammingClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub.Controllers
{
    public class MembershipTypeController : Controller
    {
        private MembershipTypeRepository membershipTypeRepository = new MembershipTypeRepository();
        // GET: MembershipType

        public ActionResult Index()
        {
            List<MembershipTypeModel> membershipTypes = membershipTypeRepository.GetAllMembershipTypes();
            return View("Index", membershipTypes);
        }

        // GET: MembershipType/Details/5
        public ActionResult Details(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeById(id);

            return View("Details", membershipTypeModel);
        }

        // GET: MembershipType/Create
        public ActionResult Create()
        {
            return View("CreateMembershipType");
        }

        // POST: MembershipType/Create
        [HttpPost]
        [Authorize(Roles = "User, Admin ")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
                UpdateModel(membershipTypeModel);
                membershipTypeRepository.InsertMembershipTypes(membershipTypeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMembershipType");
            }
        }

        // GET: MembershipType/Edit/5
        public ActionResult Edit(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeById(id);
            return View("EditMembershipType", membershipTypeModel);
        }

        // POST: MembershipType/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {

                MembershipTypeModel membershipTypeModel = new MembershipTypeModel();
                UpdateModel(membershipTypeModel);
                membershipTypeRepository.UpdateMembershipType(membershipTypeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMembershipType");
            }
        }

        // GET: MembershipType/Delete/5
        public ActionResult Delete(Guid id)
        {
            MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeById(id);
            return View("Delete", membershipTypeModel);
        }

        // POST: MembershipType/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                membershipTypeRepository.DeleteMembershipType(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
