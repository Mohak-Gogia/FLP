using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDOperationModelFirst.Models;
using CRUDOperationModelFirst.Services;

namespace CRUDOperationModelFirst.Controllers
{
    public class CandidatesController : Controller
    {
        CandidateService service = new CandidateService();

        public ActionResult Index()
        {
            return View(service.GetCandidateList());
        }

        public ActionResult Details(int? id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }

        public ActionResult Create()
        {
            return View(new Candidate());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateId,Name,Email,PhnNum,DOB,Gender,UnivName,ClgName,Branch")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {

                service.CreateCandidate(candidate);
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        public ActionResult Edit(int id)
        {
            return View(service.GetCandidate(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateId,Name,Email,PhnNum,DOB,Gender,UnivName,ClgName,Branch")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCandidate(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        public ActionResult Delete(int? id)
        {
            return View(service.GetCandidateList().Where(x => x.CandidateId == id).FirstOrDefault());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
