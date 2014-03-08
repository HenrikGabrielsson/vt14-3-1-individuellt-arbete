﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //ny kund (skickar tillbaka customerID)
            if(customer.CustomerID == null)
            {
                return CustomerDAL.NewCustomer(customer);
            }

            //uppdaterad kund (skickar tillbaka antal ändrade rader)
            else
            {
                return CustomerDAL.UpdateCustomer(customer);
            }
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

        //hämta 'en sida med uthyrningar'
        public IEnumerable<Rental> GetRentalsPagewise(int maxRows,int startIndex,int totalRowCount)
        {
            return RentalDAL.GetRentalsPagewise(maxRows,startIndex, out totalRowCount);
        }

        //skapa / uppdatera Uthyrning
        public int SaveRental(Rental rental)
        {
            //ny uthyrning (skickar tillbaka rentalID)
            if (rental.RentalID == null)
            {
                return RentalDAL.NewRental(rental);
            }

            //uppdaterad uthyrning (skickar tillbaka antal ändrade rader)
            else
            {
                return RentalDAL.UpdateRental(rental);
            }
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