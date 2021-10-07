using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamPlatform.Models;
using System.ComponentModel.DataAnnotations;


namespace ExamPlatform.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var candidate = (Candidate)validationContext.ObjectInstance;

            if (candidate.DOB == null)
                return new ValidationResult("Date of Birth is required.");

            int candidateAge = Convert.ToInt32(candidate.DOB.Substring(5));
            int age = 2021 - candidateAge;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Candidate should be at least 18 years old.");
        }
    }
}