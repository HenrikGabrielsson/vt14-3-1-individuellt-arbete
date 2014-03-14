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
            if (Session["ChangeMessage"] != null)
            {
                SuccessLabel.Text = (string)Session["ChangeMessage"];
                SuccessLabel.Visible = true;

                Session["ChangeMessage"] = null;
            }
            else if(SuccessLabel.Visible)
            {
                SuccessLabel.Visible = false;
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

                SuccessLabel.Text = "Borttagningen lyckades";
                SuccessLabel.Visible = true;
            }
            catch
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                SuccessLabel.Text = "Borttagningen misslyckades";
                SuccessLabel.Visible = true;
            }
        }
    }
}