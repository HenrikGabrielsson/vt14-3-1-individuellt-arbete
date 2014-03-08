using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Filmuthyrning.Model.BLL
{
    public class Movie
    {
        //Alla egenskaper.
        //Behöver inte validering för närvarande då det inte går att lägga till filmer i denna applikation
        public int MovieID{get;set;}
        public string Title{get;set;}
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PriceGroupID { get; set; }
        public int RentalPeriod { get; set; }
        public int Quantity { get; set; }
    }
}