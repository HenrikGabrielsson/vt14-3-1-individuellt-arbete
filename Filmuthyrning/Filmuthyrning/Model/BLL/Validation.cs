using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Filmuthyrning.Model.BLL
{
    public class Validation
    {
        //funktion som validerar uthyrningsformuläret.
        public bool ValidateRental(Rental rental, out string errorMessage)
        {
            //Kollar så en film är vald
            if(rental.MovieID == null)
            {
                errorMessage = "Du måste välja en film";
                return false;
            }

            //Kollar så en kund är vald
            if (rental.CustomerID == null)
            {
                errorMessage = "Du måste välja en kund";
                return false;
            }


            //Kollar ifall datumet är valt
            if(rental.RentalDate != null)
            {
                //kollar så datumet har rätt format
                Regex dateregex = new Regex("^[0-9]{4}-[0-9]{2}-[0-9]{2}$");
                if (!dateregex.IsMatch(rental.RentalDate))
                {
                    errorMessage = "Fel format på hyrdatumet!";
                    return false;
                }
            }

            errorMessage = "";
            return true;
        }


        public bool ValidateCustomer(Customer customer, out string errorMessage)
        {

            //kollar så förnamnet inte är tomt
            if(String.IsNullOrWhiteSpace(customer.FirstName))
            {
                errorMessage = "Kunden måste ha ett förnamn!";
                return false;
            }

            //kollar så förnamnet inte är för långt
            if(customer.FirstName.Length > 50)
            {
                errorMessage = "Förnamnet är för långt. Max 50 tecken är tillåtet.";
                return false;
            }

            //kollar så efternamnet inte är tomt
            if(String.IsNullOrWhiteSpace(customer.LastName))
            {
                errorMessage = "Kunden måste ha ett efternamn!";
                return false;
            }

            //kollar så efternamnet inte är för långt
            if(customer.LastName.Length > 50)
            {
                errorMessage="Efternamnet är för långt. Max 50 tecken är tillåtet.";
                return false;
            }

            //kollar så telefonnumret är ifyllt
            if(String.IsNullOrWhiteSpace(customer.PhoneNumber))
            {
                errorMessage = "Telefonnumret måste fyllas i";
                return false;
            }
            //kollar så telefonnumret inte är för långt
            if(customer.PhoneNumber.Length > 10)
            {
                errorMessage="Telefonnumret är för långt. Max 10 tecken är tillåtet.";
                return false;
            }

            //emailadressen får vara tom. Annars ska den valideras.
            if (!String.IsNullOrWhiteSpace(customer.Email))
            {
                //kollar så emailadressen har rätt format
                Regex emailRegex = new Regex(@".+@.+\..{2,4}");
                if (!emailRegex.IsMatch(customer.Email))
                {
                    errorMessage = "Email-adressen har fel format!";
                    return false;
                }

                //kollar så emailadressen inte är för långt
                if (customer.Email.Length > 50)
                {
                    errorMessage = "Emailadressen får vara högst 50 tecken lång!";
                    return false;
                }
            }

            errorMessage = "";
            return true;
        }
    }
}