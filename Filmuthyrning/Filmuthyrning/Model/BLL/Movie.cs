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
        public int MovieID{get;set;}
        public string Title{get;set;}
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PriceGroupID { get; set; }
        public int RentalPeriod { get; set; }
        public int Quantity { get; set; }
        public string PriceGroupText //Namnet på prisgruppen som filmen tillhör
        {
            get
            {
                switch (PriceGroupID)
                {
                    case 1: 
                        return "Låg";
                    case 2:
                        return "Medel";
                    case 3:
                        return "Hög";
                    default:
                        return null;
                }
            }
        }
    }
}