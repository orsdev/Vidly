using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customers Customers { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}