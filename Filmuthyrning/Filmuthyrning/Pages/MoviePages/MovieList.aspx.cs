using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Filmuthyrning.Model.BLL;

namespace Filmuthyrning.Pages.MoviePages
{
    public partial class MovieList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //hämta in filmerna som ska visas i listan
        public IEnumerable<Movie> MovieListView_GetData()
        {
            Service service = new Service();  
            try
            {
                return service.GetMovies();
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
    }
}