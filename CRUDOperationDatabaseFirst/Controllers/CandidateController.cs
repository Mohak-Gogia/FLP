using CRUDOperationDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperationDatabaseFirst.Controllers
{
    public class CandidateController : Controller
    {

        CandidateDBEntities db = new CandidateDBEntities();

        // GET: Candidate
        public ActionResult Index()
        {
            var data = db.Candidates.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var record = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
            return View(record);
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
                db.Candidates.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c);
        }


        public ActionResult Edit(int id)
        {
            var record = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
            return View(record);
        }


        [HttpPost]
        public ActionResult Edit(Candidate c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }


        public ActionResult Delete(int id)
        {
            var deletedRecord = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
            return View(deletedRecord);
        }


        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            var deletedRecord = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
            db.Candidates.Remove(deletedRecord);
            int resp = db.SaveChanges();
            if(resp > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}