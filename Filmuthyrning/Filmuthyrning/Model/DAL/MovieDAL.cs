using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Filmuthyrning.Model.BLL;


namespace Filmuthyrning.Model.DAL
{
    public class MovieDAL: DALBase
    {
        //Hämtar alla filmer från tabellen.
        public IEnumerable<Movie> getMovies()
        {
            try
            {
                //här ska alla filmer från databasen sparas
                List<Movie> movies = new List<Movie>(500);

                //en anslutning till databasen hämtas.
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getMoviesCmd = new SqlCommand("appSchema.getFilmer", conn);
                    getMoviesCmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = getMoviesCmd.ExecuteReader())
                    {

                        //hämta alla index i tabeller
                        int movieIDIndex = reader.GetOrdinal("FilmID");
                        int titleIndex = reader.GetOrdinal("Titel");
                        int yearIndex = reader.GetOrdinal("År");
                        int genreIndex = reader.GetOrdinal("Genre");
                        int priceGroupIDIndex = reader.GetOrdinal("Prisgrupp");
                        int rentalPeriodIndex = reader.GetOrdinal("Hyrtid");
                        int quantityIndex = reader.GetOrdinal("Antal");

                        //hämtar varje tabellrad för sig
                        while (reader.Read())
                        {
                            //hämtar och lägger till filmen i return-listan.
                            Movie movie = new Movie();
                            movie.MovieID = reader.GetInt32(movieIDIndex);
                            movie.Title = reader.GetString(titleIndex);
                            movie.Year = reader.GetInt32(yearIndex);
                            movie.Genre = reader.GetString(genreIndex);
                            movie.PriceGroupID = reader.GetInt32(priceGroupIDIndex);
                            movie.RentalPeriod = reader.GetInt32(rentalPeriodIndex);
                            movie.Quantity = reader.GetInt32(quantityIndex);

                            movies.Add(movie);
                        }
                    }
                }

                //tar bort ev. tomma poster från listan
                movies.TrimExcess();
                return movies.AsEnumerable();
            }

            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //Hämta en film med specificerat ID
        public Movie getMovieByID(int movieID)
        {
            try
            {
                Movie movie = new Movie();

                //Anslutningen som ska användas
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getMovieByIDCmd = new SqlCommand("appSchema.getFilmByID", conn);
                    getMovieByIDCmd.CommandType = CommandType.StoredProcedure;

                    getMovieByIDCmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = movieID;

                    //anslutningen öppnas
                    conn.Open();

                    using (SqlDataReader reader = getMovieByIDCmd.ExecuteReader())
                    {
                        //hämta alla index i tabeller
                        int movieIDIndex = reader.GetOrdinal("FilmID");
                        int titleIndex = reader.GetOrdinal("Titel");
                        int yearIndex = reader.GetOrdinal("År");
                        int genreIndex = reader.GetOrdinal("Genre");
                        int priceGroupIDIndex = reader.GetOrdinal("Prisgrupp");
                        int rentalPeriodIndex = reader.GetOrdinal("Hyrtid");
                        int quantityIndex = reader.GetOrdinal("Antal");

                        if(reader.Read())
                        {
                            movie.MovieID = reader.GetInt32(movieIDIndex);
                            movie.Title = reader.GetString(titleIndex);
                            movie.Year = reader.GetInt32(yearIndex);
                            movie.Genre = reader.GetString(genreIndex);
                            movie.PriceGroupID = reader.GetInt32(priceGroupIDIndex);
                            movie.RentalPeriod = reader.GetInt32(rentalPeriodIndex);
                            movie.Quantity = reader.GetInt32(quantityIndex);

                        }
                    }
                }
                return movie;
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }
    }
}