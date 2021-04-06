using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your full name")]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime DOB { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        /*
            * MembershipType is a Navigation Property, it allows
            * navigation of a type to another.
            * 
            * Customer - MembershipType
        */
        public MembershipType MembershipType { get; set; }

        /*
             * By convention in Entity Framework, MembershipTypeId is treated
             * as a Foreign key
             * 
         */
        [Required(ErrorMessage = "Select a membership type")]
        public byte MembershipTypeId { get; set; }

    }
}