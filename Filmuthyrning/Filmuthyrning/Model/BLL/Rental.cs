using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public class Rental
    {
        public int RentalID { get; set; }

        [Required(ErrorMessage = "En film måste väljas")]
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }

        [Required(ErrorMessage = "En film måste väljas")]
        public int CustomerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        [DataType(DataType.DateTime,ErrorMessage="Inmatningen kunde inte tolkas som ett datum")]
        [Range (typeof(DateTime), "1900-01-01","2079-06-06",ErrorMessage="Datumet måste ligga mellan 1900-01-01 och 2079-06-06")]
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}