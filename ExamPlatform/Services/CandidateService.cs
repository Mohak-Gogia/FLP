using ExamPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPlatform.Services
{

    // Implementing Singleton Class
    public sealed class CandidateService
    {
        private IList<Candidate> candidateList = null;

        private static CandidateService instance = null;

        public static CandidateService GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new CandidateService();
                return instance;
            }
        }

        private CandidateService()
        {
            InitializeCandidateList();
        }

        private void InitializeCandidateList()
        {
            // Dummy data
            candidateList = new List<Candidate>{
                new Candidate() { CandidateId = 2, Name = "Ravi", Email = "ravi@gmail.com" ,
                    PhnNum = "9998723190" , DOB = "12-09-1998" , Gender = "Male" ,
                    UnivName = "Amity University" , ClgName = "Amity" , Branch = "ECE"} ,

                new Candidate() { CandidateId = 1, Name = "Kritika", Email = "kritika01@gmail.com" ,
                    PhnNum = "9998213190" , DOB = "11-02-1998" , Gender = "Female" ,
                    UnivName = "Amity University" , ClgName = "Amity" , Branch = "CSE"} ,

                new Candidate() { CandidateId = 3, Name = "Harshit", Email = "harshit@gmail.com" ,
                    PhnNum = "9998722312" , DOB = "28-11-1999" , Gender = "Male" ,
                    UnivName = "GGSIPU" , ClgName = "HMR College" , Branch = "IT"}
            };
        }


        public IList<Candidate> GetCandidateList()
        {
            return candidateList;
        }

        public Candidate GetCandidate(int id)
        {
            return candidateList.Where(x => x.CandidateId == id).FirstOrDefault();
        }

       
        public void CreateCandidate(Candidate candidate)
        {

            /*Candidate existingCandidate = candidateList.Where(x => x.Name == candidate.Name
                                         && x.Email == candidate.Email && x.PhnNum == candidate.PhnNum && x.DOB == candidate.DOB
                                         && x.Gender == candidate.Gender && x.UnivName == candidate.UnivName
                                         && x.ClgName == candidate.ClgName && x.Branch == candidate.Branch).FirstOrDefault();*/
            Candidate existingCandidate = null;
            foreach (Candidate c in candidateList)
            {
                if (c == candidate)
                {
                    existingCandidate = candidate;
                    break;
                }
            }

            if (existingCandidate == null)
            {
                candidate.CandidateId = candidateList.Any() ? candidateList.Max(x => x.CandidateId)+1 : 1;
                candidateList.Add(candidate);   
            }
            else
            {
                throw new Exception("Candidate already exist");
            }
        }


        public void UpdateCandidate(Candidate candidate)
        {
            Candidate candidateToUpdate = candidateList.Where(x => x.CandidateId == candidate.CandidateId).FirstOrDefault();
            if (candidateToUpdate != null)
            {
                candidateToUpdate.Name = candidate.Name;
                candidateToUpdate.Email = candidate.Email;
                candidateToUpdate.PhnNum = candidate.PhnNum;
                candidateToUpdate.Gender = candidate.Gender;
                candidateToUpdate.DOB = candidate.DOB;
                candidateToUpdate.UnivName = candidate.UnivName;
                candidateToUpdate.ClgName = candidate.ClgName;
                candidateToUpdate.Branch = candidate.Branch;
            }
            else
            {
                throw new Exception("Candidate doesn't exist");
            }
        }

        public void RemoveCandidate(int id)
        {
            bool ifCandidateExists = candidateList.Any(x => x.CandidateId == id);

            if (ifCandidateExists)
            {
                Candidate candidateToDelete = candidateList.Where(x => x.CandidateId == id).FirstOrDefault();
                candidateList.Remove(candidateToDelete);
            }
            else
            {
                throw new Exception("Invalid Candidate Id");
            }
        }
    }
}