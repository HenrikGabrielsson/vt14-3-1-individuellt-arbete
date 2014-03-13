using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;

namespace Filmuthyrning.Pages.RentalPages
{
    public partial class RentalList : System.Web.UI.Page
    {
        //nytt Service-objekt
        Service _service;
        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Om man skickas till denna sida efter en lyckad sparning så visas ett meddelande som konfirmerar att det fungerade
            if(Session["SaveComplete"] != null && (bool)Session["SaveComplete"]== true)
            {
                SuccessLabel.Text = "Sparningen lyckades!";
                SuccessLabel.Visible = true;
                Session["SaveComplete"] = null;
            }
        }

        //Fyller tabellen med data
        public IEnumerable<Rental> RentalListView_GetData()
        {
            try
            {
                return Service.GetRentals();
            }
            catch
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = "Något gick fel när uthyrningarna skulle hämtas.";
                Page.Validators.Add(error);
                return null;                
            }
        }


        //Tar bort en post
        public void RentalListView_DeleteItem(int RentalID)
        {
            try
            {
                Service.DeleteRental(RentalID);
            }
            catch
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = "Något gick fel när uthyrningen skulle raderas.";
                Page.Validators.Add(error); 
            }
        }


    }
}