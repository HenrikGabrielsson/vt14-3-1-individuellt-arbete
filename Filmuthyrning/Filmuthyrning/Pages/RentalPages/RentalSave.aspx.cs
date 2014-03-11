using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmuthyrning.Pages.RentalPages
{
    public partial class RentalUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int rentalID = 0;
            //hämta uthyrningsid som ska ändras. Om det är 0 så är det en ny uthyrning
            if (Request.QueryString["Rental"] != null)
            {

                rentalID = int.Parse(Request.QueryString["Rental"]);
            }

        }
    }
}