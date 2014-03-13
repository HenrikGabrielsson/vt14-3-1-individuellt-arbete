using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;
using System.Text.RegularExpressions;

namespace Filmuthyrning.Pages.RentalPages
{
    public partial class RentalUpdate : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Rental rental;
                int rentalID = 0;

                //hämta uthyrning som ska ändras. Om det är 0 så är det en ny uthyrning
                if (Request.QueryString["Rental"] != null)
                {
                    rentalID = int.Parse(Request.QueryString["Rental"]);
                }


                //Om det är en uthyrning som ska uppdateras.
                if (rentalID != 0)
                {
                    rental = Service.getRentalByID(rentalID);

                    //regex för att plocka ut datum och inte tid
                    Regex dateRegex = new Regex("\\s[0-9]{2}:[0-9]{2}:[0-9]{2}");

                    //sätt de gamla värdena i formuläret
                    DateBox.Text = dateRegex.Split(rental.RentalDate)[0];
                    MovieDropDownList.SelectedValue = rental.MovieID.ToString();
                    CustomerDropDownList.SelectedValue = rental.CustomerID.ToString();

                    SaveButton.Text = "Spara ändringar";
                }

                //Om det är en ny uthyrning
                else
                {
                    SaveButton.Text = "Lägg till";
                }
            }

        }

        //metod som hämtar alla filmer som kan hyras ut.
        public IEnumerable<Movie> MovieDropDownList_GetData()
        {
            try
            {
                return Service.GetAvailMovies();
            }
            catch
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = "Något gick fel när filmerna skulle hämtas.";
                Page.Validators.Add(error);
                return null;   
            }
        }

        //metod som hämtar alla kunder
        public IEnumerable<Customer> CustomerDropDownList_GetData()
        {
            try
            {
                return Service.GetCustomers();
            }
            catch
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = "Något gick fel när kunderna skulle hämtas.";
                Page.Validators.Add(error);
                return null;  
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Rental rental = new Rental();
                int rentalID = 0;

                //hämta rentalid som ska ändras. Om det är 0 så är det en ny rental
                if (Request.QueryString["Rental"] != null)
                {
                    rentalID = int.Parse(Request.QueryString["Rental"]);
                }

                //hämta alla uppgifter
                rental.MovieID = int.Parse(MovieDropDownList.SelectedValue);
                rental.CustomerID = int.Parse(CustomerDropDownList.SelectedValue);
                rental.RentalDate = DateBox.Text;

                //om det är en uthyrning som ska uppdateras så behåller den sitt gamla id
                if (rentalID != 0)
                {
                    rental.CustomerID = rentalID;

                }

                //uthyrningen sparas
                Service.SaveRental(rental);

                //Ett meddelande skickas till nästa sida och säger att sparningen lyckades
                Session["SaveMessage"] = "Sparningen lyckades!";
                Response.Redirect("~/Uthyrning/Lista",false);

            }
            catch(Exception ex)
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                Session["SaveMessage"] = ex.Message;
                Response.Redirect("~/Uthyrning/Lista", false);
            }



        }


    }
}