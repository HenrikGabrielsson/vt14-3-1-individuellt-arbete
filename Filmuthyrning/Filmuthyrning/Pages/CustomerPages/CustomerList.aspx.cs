using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;

namespace Filmuthyrning.Pages.CustomerPages
{
    public partial class CustomerList : System.Web.UI.Page
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
            if (Session["SaveMessage"] != null)
            {
                SuccessLabel.Text = (string)Session["SaveMessage"];
                SuccessLabel.Visible = true;
                Session["SaveMessage"] = null;
            }

        }


        public IEnumerable<Customer> ListView_Customer_GetData()
        {
            try
            {
                return Service.GetCustomers();
            }
            catch
            {
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = "Något gick fel när kunderna skulle hämtas.";
                Page.Validators.Add(error);
                return null;
            }
        }

        //Ta bort kunden
        public void ListView_Customer_DeleteItem(int CustomerID)
        {
            Service.DeleteCustomer(CustomerID);
        }
    }
}