using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CRUDOperationModelFirst.Models;

namespace CRUDOperationModelFirst.Services
{
    public class CandidateService
    {
        private CandidateContainer db = new CandidateContainer();

        public IList<Candidate> GetCandidateList()
        {
            var candidateList = db.Candidates.ToList();
            return candidateList;
        }

        public Candidate GetCandidate(int id)
        {
            Candidate c = db.Candidates.Where(x => x.CandidateId == id).SingleOrDefault();
            return c;
        }

        public void CreateCandidate(Candidate c)
        {
            db.Candidates.Add(c);
            db.SaveChanges();
        }

        public void UpdateCandidate(Candidate c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveCandidate(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate != null)
            {
                db.Candidates.Remove(candidate);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid Candidate Id");
            }
        }
    }
}