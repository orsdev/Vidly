using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;

            /*
                * MembershipType.Unknown = 0
                * MembershipType.PayAsYouGo = 1
             */
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DOB == null)
            {
                return new ValidationResult("DOB is required");
            }

            var age = DateTime.Today.Year - customer.DOB.Year;

            return age < 18 ? new ValidationResult("Customer should be atleast 18 years of age")
                : ValidationResult.Success;

        }
    }
}