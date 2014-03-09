using System;
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

        }

        //Fyller tabellen med data
        public IEnumerable<Rental> RentalListView_GetData()
        {
            return Service.GetRentals();
        }


    }
}