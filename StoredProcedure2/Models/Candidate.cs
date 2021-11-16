using StoredProcedure2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoredProcedure2.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhnNum { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string UnivName { get; set; }

        public string ClgName { get; set; }

        public string Branch { get; set; }

    }
}

