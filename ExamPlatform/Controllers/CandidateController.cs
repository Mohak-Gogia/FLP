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

        // Creating instance of Candidate Service
        CandidateService service = CandidateService.GetInstance;

        
        // 1. READ OPERATION

        // GET: /Candidate
        public ActionResult Index()
        {
            return View(service.GetCandidateList());
        }
        
        // Get: /Candidate/Details/{id}
        public ActionResult Details(int id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }

        // 2. Create OPERATION

        // GET: /Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Candidate c)
        {
            try
            {
                service.CreateCandidate(c);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 3. UPDATE OPERATION

        // Get : /Candidate/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View(service.GetCandidate(id));
        }

        [HttpPost]
        public ActionResult Edit(Candidate c)
        {
            service.UpdateCandidate(c);
            return RedirectToAction("Index");
        }

       
        // 4. DELETE OPERATION

        // Get: /Canddidate/Delete/{id}
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