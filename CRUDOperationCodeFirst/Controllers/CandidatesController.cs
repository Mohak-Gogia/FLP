using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using CRUDOperationCodeFirst.Models;
using CRUDOperationCodeFirst.Services;

namespace CRUDOperationCodeFirst.Controllers
{
    public class CandidatesController : ApiController
    {
        CandidateService service = new CandidateService();

        [HttpGet]
        [Route("[action]")]
        [Route("api/Candidates/Get")]
        public IEnumerable<Candidate> Get()
        {
            return service.GetCandidateList();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Candidates/GetCandidateById/{id}")]
        public Candidate GetEmployeeId(int id)
        {
            return service.GetCandidate(id);
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Candidates/AddCandidate")]
        public string AddCandidate(Candidate c)
        {
            service.CreateCandidate(c);
            return "Candidate Successfully Added";
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Candidates/EditCandidate")]
        public string EditCandidate(Candidate c)
        {
            service.UpdateCandidate(c);
            return "Candidate Successfully Edited";
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Candidates/DeleteCandidate/{id}")]
        public string DeleteCandidate(int id)
        {
            service.RemoveCandidate(id);
            return "Candidate Successfully Deleted";
        }

       
    }
}