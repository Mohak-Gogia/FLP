using CRUDOperationCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationCodeFirst.Services
{
    public class CandidateService
    {
        private Models.MyDBContext _context;

        public CandidateService()
        {
            _context = new Models.MyDBContext();
        }

        public IList<Candidate> GetCandidateList()
        {
            var candidateList = _context.Candidate.ToList();
            return candidateList;
        }

        public Candidate GetCandidate(int id)
        {
            Candidate c = _context.Candidate.Where(x => x.CandidateId == id).SingleOrDefault();
            return c;
        }

        public void CreateCandidate(Candidate c)
        {
            _context.Candidate.Add(c);
            _context.SaveChanges();
        }

        public void UpdateCandidate(Candidate c)
        {
            Candidate candidate = _context.Candidate.Where(x => x.CandidateId == c.CandidateId).SingleOrDefault();
            if (candidate != null)
            {
                _context.Entry(candidate).CurrentValues.SetValues(c);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Candidate doesn't exist");
            }
        }

        public void RemoveCandidate(int id)
        {
            Candidate candidate = _context.Candidate.Where(x => x.CandidateId == id).SingleOrDefault();
            if (candidate != null)
            {
                _context.Candidate.Remove(candidate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid Candidate Id");
            }
        }
    }
}