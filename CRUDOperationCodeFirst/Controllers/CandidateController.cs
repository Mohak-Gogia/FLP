using CRUDOperationCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperationCodeFirst.Controllers
{
    public class CandidateController : Controller
    {
        private Models.MyDBContext _context;

        public CandidateController()
        {
            _context = new Models.MyDBContext();
        }

        public ActionResult Index()
        {
            var candidateList = _context.Candidate.ToList();
            return View(candidateList);
        }


        public ViewResult Details(int id)
        {
            Candidate candidate = _context.Candidate.Where(x => x.CandidateId == id).SingleOrDefault();
            return View(candidate);
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
                _context.Candidate.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }


        public ActionResult Edit(int id)
        {
            Candidate c = _context.Candidate.Where(x => x.CandidateId == id).SingleOrDefault();
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Candidate c)
        {
            Candidate candidate = _context.Candidate.Where(x => x.CandidateId == c.CandidateId).SingleOrDefault();
            if (ModelState.IsValid)
            {
                _context.Entry(candidate).CurrentValues.SetValues(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }


        public ActionResult Delete(int id)
        {
            Candidate c = _context.Candidate.Find(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Delete(int id, Candidate c)
        {
            var candidate = _context.Candidate.Where(x => x.CandidateId == id).SingleOrDefault();
            if (candidate != null)
            {
                _context.Candidate.Remove(candidate);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}