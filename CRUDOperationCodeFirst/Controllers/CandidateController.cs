using CRUDOperationCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperationCodeFirst.Services;

namespace CRUDOperationCodeFirst.Controllers
{
    public class CandidateController : Controller
    {
        CandidateService service = new CandidateService();

        public ActionResult Index()
        {
            return View(service.GetCandidateList());
        }


        public ViewResult Details(int id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }


        public ActionResult Create()
        {
            return View(new Candidate());
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Create(Candidate c)
        {
            if (ModelState.IsValid)
            {
                service.CreateCandidate(c); 
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }


        public ActionResult Edit(int id)
        {
            return View(service.GetCandidate(id));
        }

        [HttpPost]
        public ActionResult Edit(Candidate c)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCandidate(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }


        public ActionResult Delete(int id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Candidate c)
        {
            try
            {
                service.RemoveCandidate(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}