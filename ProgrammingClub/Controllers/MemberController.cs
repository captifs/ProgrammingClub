using ProgrammingClub.Models;
using ProgrammingClub.Models.ViewModels;
using ProgrammingClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub.Controllers
{
    public class MemberController : Controller
    {
        private MemberRepository repository = new MemberRepository();
        // GET: Member
        public ActionResult Index()
        {
            List<MemberModel> members = repository.GetAllMembers();
            return View("Index",members);
        }

        // GET: Member/Details/5
        public ActionResult DetailsViewModel(Guid id)
        {
            MemberCodeSnippetsViewModel viewModel = repository.GetMemberCodeSnippets(id);

            return View("DetailsViewModel", viewModel);
        }

        public ActionResult Details(Guid id)
        {
            MemberModel memberModel = repository.GetMemberById(id);
            return View("DetailsViewModel", memberModel);
        }



        // GET: Member/Create
        public ActionResult Create()
        {
            return View("CreateMember");
        }

        // POST: Member/Create

        [Authorize(Roles = "User, Admin ")]
        [HttpPost]

        public ActionResult Create(FormCollection collection)
        {
            try
            {
                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                repository.InsertMember(memberModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMember");
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(Guid id)
        {
            MemberModel memberModel = repository.GetMemberById(id);
           
            return View("EditMember",memberModel);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                MemberModel memberModel = new MemberModel();
                UpdateModel(memberModel);
                repository.UpdateMember(memberModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMember");
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(Guid id)
        {
            MemberModel memberModel = repository.GetMemberById(id);
            return View("Delete", memberModel) ;
        }

        // POST: Member/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                repository.DeleteMember(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
