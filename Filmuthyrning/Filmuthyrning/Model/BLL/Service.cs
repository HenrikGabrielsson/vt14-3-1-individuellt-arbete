using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Filmuthyrning.Model.DAL;
using System.Web.UI;

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
            try
            {
                return CustomerDAL.getCustomers();
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //hämta en kund
        public Customer getCustomerByID(int customerID)
        {
            try
            {
                return CustomerDAL.getCustomerByID(customerID);
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //skapa / uppdatera kund
        public void SaveCustomer(Customer customer)
        {
            Validation val = new Validation();

            string errorMessage ="";

            try
            {
                if (val.ValidateCustomer(customer, out errorMessage))
                {
                    //ny kund (skickar tillbaka customerID)
                    if (customer.CustomerID == 0)
                    {
                        CustomerDAL.NewCustomer(customer);
                    }

                    //uppdaterad kund (skickar tillbaka antal ändrade rader)
                    else
                    {
                        CustomerDAL.UpdateCustomer(customer);
                    }
                }
                else
                {
                    throw new ApplicationException(errorMessage);
                }
            }
            catch
            {
                throw new ApplicationException(errorMessage);
            }

        }

        //ta bort kund
        public void DeleteCustomer(int customerID)
        {
            try
            {
                //skickar tillbaka antal ändrade rader
                CustomerDAL.DeleteCustomer(customerID);
            }
            catch
            {
                throw new ApplicationException();
            }
        }




        //Funktioner för Uthyrningar
        //hämta alla uthyrningar
        public IEnumerable<Rental> GetRentals()
        {
            try
            {
                return RentalDAL.getRentals();
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //hämta en uthyrning
        public Rental getRentalByID(int rentalID)
        {
            try
            {
                return RentalDAL.getRentalByID(rentalID);
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //skapa / uppdatera Uthyrning
        public void SaveRental(Rental rental)
        {
            //Validering
            Validation val = new Validation();
            string errorMessage ="";

            try
            {
                if (val.ValidateRental(rental, out errorMessage))
                {
                    //ny uthyrning (skickar tillbaka rentalID)
                    if (rental.RentalID == 0)
                    {
                        RentalDAL.NewRental(rental);
                    }

                    //uppdaterad uthyrning (skickar tillbaka antal ändrade rader)
                    else
                    {
                        RentalDAL.UpdateRental(rental);
                    }
                }

                //Om valideringen inte är godkänd
                else
                {
                    throw new ApplicationException(errorMessage);
                }
            }
            catch
            {
                throw new ApplicationException(errorMessage);
            }
        }

        //ta bort uthyrning
        public void DeleteRental(int rentalID)
        {
            try
            {
                //skickar tillbaka antal ändrade rader
                RentalDAL.DeleteRental(rentalID);
            }
            catch
            {
                throw new ApplicationException();
            }
        }
       




        //Funktioner för filmer
        //hämta alla filmer
        public IEnumerable<Movie> GetMovies()
        {
            try
            {
                return MovieDAL.getMovies();
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //hämta bara filmer där antalet inte är 0
        public IEnumerable<Movie> GetAvailMovies()
        {
            List<Movie> availMovies = new List<Movie>(100);

            try
            {
                //lägger till alla filmer som går att hyra.
                foreach (Movie movie in GetMovies())
                {
                    if (movie.Quantity > 0)
                    {
                        availMovies.Add(movie);
                    }
                }
                availMovies.TrimExcess();
                return availMovies;
            }
            catch
            {
                throw new ApplicationException();
            }
        }

        //hämta en film
        public Movie getMovieByID(int movieID)
        {
            try
            {
                return MovieDAL.getMovieByID(movieID);
            }
            catch
            {
                throw new ApplicationException();
            }
        }

    }
}