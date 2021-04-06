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

        [Required]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
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
        public byte MembershipTypeId { get; set; }

    }
}