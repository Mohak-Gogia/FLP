using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamPlatform.Models
{
    public class Candidate
    { 
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhnNum { get; set; }

        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        public string Gender { get; set; }

        [Display(Name = "University Name")]
        public string UnivName { get; set; }

        [Display(Name = "College Name")]
        public string ClgName { get; set; }

        public string Branch { get; set; }
    }
}