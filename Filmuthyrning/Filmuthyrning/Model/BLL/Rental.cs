using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public class Rental
    {
        //Alla egenskaper med validering
        public int RentalID { get; set; }

        [Required(ErrorMessage="En film måste väljas!")]
        
        public int MovieID { get; set; }

        public string MovieTitle { get; set; }

        [Required(ErrorMessage="En kund måste väljas!")]
        public int CustomerID { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string RentalDate { get; set; }
    }
}