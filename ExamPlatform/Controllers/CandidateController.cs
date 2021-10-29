using ExamPlatform.Models;
using ExamPlatform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamPlatform.Controllers
{
    public class CandidateController : Controller
    {
        CandidateService service = CandidateService.GetInstance;

        public ActionResult Index()
        {
            return View(service.GetCandidateList());
        }
        

        public ActionResult Details(int id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }


        public ActionResult Create()
        {
            return View();
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
        public ActionResult Delete(int id,FormCollection collection)
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