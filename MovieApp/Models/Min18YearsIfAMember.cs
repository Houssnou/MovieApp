using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if( customer.MembershipTypeId==MembershipType.Unknown ||
                customer.MembershipTypeId==MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Dob == null)
                return new ValidationResult("Date Of Birth is required");

            var age = DateTime.Today.Year - customer.Dob.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years to apply for a membership");
        }
    }
}