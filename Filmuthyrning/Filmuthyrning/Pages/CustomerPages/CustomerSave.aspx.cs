using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;

namespace Filmuthyrning.Pages.CustomerPages
{
    public partial class CustomerSave : System.Web.UI.Page
    {
        //Ett service-objekt
        Service _service;
        public Service Service
        {
            get{return _service ?? (_service = new Service());}
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Customer customer;
                int customerID = 0;

                //hämta kundid som ska ändras. Om det är 0 så är det en ny kund
                if (Request.QueryString["Customer"] != null)
                {
                    customerID = int.Parse(Request.QueryString["Customer"]);
                }


                //Om det är en kund som ska uppdateras.
                if (customerID != 0)
                {
                    try
                    {
                        customer = Service.getCustomerByID(customerID);
 
                        //fyller i textfälten med den gamla datan.
                        fNameBox.Text = customer.FirstName;
                        lNameBox.Text = customer.LastName;
                        phoneBox.Text = customer.PhoneNumber;
                        emailBox.Text = customer.Email;
                    }

                    catch
                    {
                        //om undantag fångas så skrivs ett felmeddelande ut
                        CustomValidator error = new CustomValidator();
                        error.IsValid = false;
                        error.ErrorMessage = "Det gick inte att hämta kunduppgifterna";
                        Page.Validators.Add(error);
                    }

                    SaveButton.Text = "Spara ändringar";
                }

                //Om det är en ny kund
                else
                {
                    SaveButton.Text = "Lägg till";
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            int customerID = 0;

            try
            {
                //hämta kundid som ska ändras. Om det är 0 så är det en ny kund
                if (Request.QueryString["Customer"] != null)
                {
                    customerID = int.Parse(Request.QueryString["Customer"]);
                }

                //hämta alla uppgifter
                customer.FirstName = fNameBox.Text;
                customer.LastName = lNameBox.Text;
                customer.PhoneNumber = phoneBox.Text;
                customer.Email = emailBox.Text;

                //om det är en kund som ska uppdateras så behåller den sitt gamla id
                if (customerID != 0)
                {
                    customer.CustomerID = customerID;

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

            try
            {
                //kunden sparas
                Service.SaveCustomer(customer);
            }

            catch(Exception ex)
            {
                //om undantag fångas så skrivs ett felmeddelande ut
                CustomValidator error = new CustomValidator();
                error.IsValid = false;
                error.ErrorMessage = ex.Message;
                Page.Validators.Add(error);
            }
        }


        
    }
}