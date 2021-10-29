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

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please provide a 10 digit number")]
        public string PhnNum { get; set; }
   
        [Display(Name = "Date of Birth")]
        [Min18Years]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "University Name is required")]
        [Display(Name = "University Name")]
        public string UnivName { get; set; }

        [Required(ErrorMessage = "College Name is required")]
        [Display(Name = "College Name")]
        public string ClgName { get; set; }

        [Required(ErrorMessage = "Branch is required")]
        public string Branch { get; set; }
    }
}