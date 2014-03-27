using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

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
            Rental rental;
            int rentalID = 0;

            //hämta uthyrning som ska ändras. Om det är 0 så är det en ny uthyrning
            if (Request.QueryString["Rental"] != null)
            {
                rentalID = int.Parse(Request.QueryString["Rental"]);
            }

            //Sätter texten på knappen
            SaveButton.Text = rentalID != 0 ? "Spara ändringar" : "Lägg till";


            if (!IsPostBack)
            {
                //Om det är en uthyrning som ska uppdateras.
                if (rentalID != 0)
                {
                    rental = Service.getRentalByID(rentalID);

                    //sätt de gamla värdena i formuläret
                    DateBox.Text = rental.RentalDate.ToString("yyyy-MM-dd");
                    MovieDropDownList.SelectedValue = rental.MovieID.ToString();
                    CustomerDropDownList.SelectedValue = rental.CustomerID.ToString();
                }

                //Om det är en ny uthyrning
                else
                {
                    DateBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
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
            if (IsValid)
            {

                Rental rental = new Rental();
                int rentalID = 0;

                try
                {
                    //hämta rentalid som ska ändras. Om det är 0 så är det en ny rental
                    if (Request.QueryString["Rental"] != null)
                    {
                        rentalID = int.Parse(Request.QueryString["Rental"]);
                    }

                    //hämta alla uppgifter
                    rental.MovieID = int.Parse(MovieDropDownList.SelectedValue);
                    rental.CustomerID = int.Parse(CustomerDropDownList.SelectedValue);
                    rental.RentalDate = String.IsNullOrWhiteSpace(DateBox.Text) ? DateTime.Now : Convert.ToDateTime(DateBox.Text); //skickar med dagens datum(och tid) om textrutan är tom.

                    //om det är en uthyrning som ska uppdateras så behåller den sitt gamla id
                    if (rentalID != 0)
                    {
                        rental.RentalID = rentalID;
                    }
                

                    try
                    {
                        //uthyrningen sparas
                        Service.SaveRental(rental);
                        //Ett meddelande skickas till nästa sida och säger att sparningen lyckades
                        Session["ChangeMessage"] = "Sparningen lyckades!";
                        Response.Redirect("~/Uthyrning/Lista", false);
                    }
                    catch (Exception ex)
                    {
                        //hämtar felmeddelanden som kan ha skapats av data annotations i customer-klassen
                        var valResults = ex.Data["ValidationResults"] as IEnumerable<ValidationResult>;

                        if (valResults != null) //Om det finns felmeddelanden
                        {
                            foreach (var valResult in valResults) 
                            {
                                foreach (var memberName in valResult.MemberNames)
                                {
                                    ModelState.AddModelError(memberName, valResult.ErrorMessage); //skriver ut varje felmeddelande
                                }
                            }
                        }
                        else //Andra undantag kastas vidare
                        {
                            throw ex;
                        }
                    }

                }
                catch
                {
                    //om undantag fångas så skrivs ett felmeddelande ut
                    CustomValidator error = new CustomValidator();
                    error.IsValid = false;
                    error.ErrorMessage = "Något gick fel när uppgifterna skulle sparas";
                    Page.Validators.Add(error);
                }
            }



        }


    }
}