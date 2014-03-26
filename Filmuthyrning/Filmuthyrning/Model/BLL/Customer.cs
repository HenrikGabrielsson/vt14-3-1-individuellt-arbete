﻿using System;
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

        [Required(ErrorMessage = "Kunden måste ha ett förnamn.")]
        [StringLength(50, ErrorMessage = "Förnamnet får inte vara längre än 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kunden måste ha ett efternamn.")]
        [StringLength(50, ErrorMessage = "Efternamnet får inte vara längre än 50 tecken.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kunden måste ha ett telefonnummer.")]
        [StringLength(10, ErrorMessage = "Telefonnumret får inte vara längre än 10 tecken.")]
        [RegularExpression("^[0-9]{1,10}$",ErrorMessage="Telefonnumret får bara bestå av siffror")]
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