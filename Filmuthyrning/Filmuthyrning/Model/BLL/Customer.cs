using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public class Customer
    {
        //Alla egenskaper med validering
        public int CustomerID { get; set; }
        public int CustomerTypeID { get; set; }

        [Required(ErrorMessage="Du måste fylla i förnamnet")]
        [StringLength(50, ErrorMessage = "Efternamnet får högst vara 50 tecken långt")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i efternamnet")]
        [StringLength(50, ErrorMessage = "Efternamnet får högst vara 50 tecken långt")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i telefonnumret")]
        [StringLength(10,ErrorMessage="Telefonnumret får högst vara 10 tecken långt")]
        public string PhoneNumber { get; set; }
    
        [StringLength(50,ErrorMessage="Adressen får inte vara längre än 50 tecken")]
        public string Email { get; set; }
    }
}