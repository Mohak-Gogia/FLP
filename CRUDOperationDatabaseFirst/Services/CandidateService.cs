using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CRUDOperationDatabaseFirst.Models;

namespace CRUDOperationDatabaseFirst.Services
{
    public class CandidateService
    {
        CandidateDBEntities db = new CandidateDBEntities();

        public IList<Candidate> GetCandidateList()
        {
            var candidateList = db.Candidates.ToList();
            return candidateList;
        }

        public Candidate GetCandidate(int id)
        {
            Candidate c = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
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
            var deletedRecord = db.Candidates.Where(model => model.CandidateId == id).FirstOrDefault();
            db.Candidates.Remove(deletedRecord);
            db.SaveChanges();
        }
    }
}