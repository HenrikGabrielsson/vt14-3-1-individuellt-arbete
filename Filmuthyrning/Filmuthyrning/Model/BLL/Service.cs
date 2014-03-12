using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Filmuthyrning.Model.DAL;

namespace Filmuthyrning.Model.BLL
{
    public class Service
    {
        //en DAL-klass för varje klass hämtas 
        private CustomerDAL _customerDAL;
        private MovieDAL _movieDAL;
        private RentalDAL _rentalDAL;

        //egenskaper som returner Dataåtkomstklasserna. 
        private CustomerDAL CustomerDAL { get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); } }
        private MovieDAL MovieDAL { get { return _movieDAL ?? (_movieDAL = new MovieDAL()); } }
        private RentalDAL RentalDAL { get { return _rentalDAL ?? (_rentalDAL = new RentalDAL()); } }

        //Funktioner för Kunder
        //hämta alla kunder
        public IEnumerable<Customer> GetCustomers()
        {
            return CustomerDAL.getCustomers();
        }

        //hämta en kund
        public Customer getCustomerByID(int customerID)
        {
            return CustomerDAL.getCustomerByID(customerID);
        }

        //skapa / uppdatera kund
        public int SaveCustomer(Customer customer)
        {
            Validation val = new Validation();

            string errorMessage;
            if (val.ValidateCustomer(customer,out errorMessage))
            {
                //ny kund (skickar tillbaka customerID)
                if (customer.CustomerID == 0)
                {
                    return CustomerDAL.NewCustomer(customer);
                }

                //uppdaterad kund (skickar tillbaka antal ändrade rader)
                else
                {
                    return CustomerDAL.UpdateCustomer(customer);
                }
            }
            return 0;
        }

        //ta bort kund
        public int DeleteCustomer(int customerID)
        {
            //skickar tillbaka antal ändrade rader
            return CustomerDAL.DeleteCustomer(customerID);
        }




        //Funktioner för Uthyrningar
        //hämta alla uthyrningar
        public IEnumerable<Rental> GetRentals()
        {
            return RentalDAL.getRentals();
        }

        //hämta en uthyrning
        public Rental getRentalByID(int rentalID)
        {
            return RentalDAL.getRentalByID(rentalID);
        }

        //skapa / uppdatera Uthyrning
        public int SaveRental(Rental rental)
        {
            Validation val = new Validation();

            string errorMessage;
            if (val.ValidateRental(rental, out errorMessage))
            {
                //ny uthyrning (skickar tillbaka rentalID)
                if (rental.RentalID == 0)
                {
                    return RentalDAL.NewRental(rental);
                }

                //uppdaterad uthyrning (skickar tillbaka antal ändrade rader)
                else
                {
                    return RentalDAL.UpdateRental(rental);
                }
            }
            return 0;
        }

        //ta bort uthyrning
        public int DeleteRental(int rentalID)
        {
            //skickar tillbaka antal ändrade rader
            return RentalDAL.DeleteRental(rentalID);
        }
       

        //Funktioner för filmer
        //hämta alla filmer
        public IEnumerable<Movie> GetMovies()
        {
            return MovieDAL.getMovies();
        }

        //hämta en film
        public Movie getMovieByID(int movieID)
        {
            return MovieDAL.getMovieByID(movieID);
        }

    }
}