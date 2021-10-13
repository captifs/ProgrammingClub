using ProgrammingClub.Models;
using ProgrammingClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClub.Controllers
{
    public class CodeSnippetController : Controller
    {
        CodeSnippetRepository codeSnippetRepository = new CodeSnippetRepository();
        // GET: CodeSnippet
        public ActionResult Index()
        {
            List<CodeSnippetModel> codeSnippets = codeSnippetRepository.GetAll();
    
            return View("Index",codeSnippets);
        }

        // GET: CodeSnippet/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CodeSnippet/Create
        [Authorize(Roles = "User, Admin ")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.InsertCodeSnippet(codeSnippetModel);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Create");
            }
        }

        // GET: CodeSnippet/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);
            return View("EditCodeSnippet",codeSnippetModel);
        }

        // POST: CodeSnippet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                UpdateModel(codeSnippetModel);
                codeSnippetRepository.UpdateCodeSnippet(codeSnippetModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCodeSnippet");
            }
        }


        public ActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);

            return View("Details", codeSnippetModel);
        }

        // GET: CodeSnippet/Delete/5
        public ActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetById(id);
            return View("Delete",codeSnippetModel);
        }

        // POST: CodeSnippet/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {

                codeSnippetRepository.DeleteCodeSnippet(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
