using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class CustomerFormViewModel
    {
       // public List<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Formtitle
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer Infos";

                return "Adding a customer";
            }
        }
    }
}