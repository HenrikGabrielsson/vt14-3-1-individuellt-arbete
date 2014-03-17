using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int CustomerTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }  
        public string BothNames //Efternamn, förnamn
        { 
            get
            {
                return String.Format("{0}, {1}", LastName, FirstName);
            }
        }
    }
}