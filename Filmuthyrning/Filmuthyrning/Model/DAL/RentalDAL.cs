using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Filmuthyrning.Model.BLL;


namespace Filmuthyrning.Model.DAL
{
    public class RentalDAL : DALBase
    {
        //Hämtar alla uthyrningar från tabellen.
        public IEnumerable<Rental> getRentals()
        {
            try
            {
                //här ska alla uthyrningar från databasen sparas
                List<Rental> rentals = new List<Rental>(1000);

                //en anslutning till databasen hämtas.
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getRentalsCmd = new SqlCommand("appSchema.usp_getUthyrningar", conn);
                    getRentalsCmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = getRentalsCmd.ExecuteReader())
                    {

                        //hämta alla index i tabeller
                        int rentalIDIndex = reader.GetOrdinal("UthyrningID");
                        int movieIDIndex = reader.GetOrdinal("FilmID");
                        int titleIndex = reader.GetOrdinal("Titel");
                        int customerIDIndex = reader.GetOrdinal("KundID");
                        int firstNameIndex = reader.GetOrdinal("Förnamn");
                        int lastNameIndex = reader.GetOrdinal("Efternamn");
                        int rentalDateindex = reader.GetOrdinal("HyrDatum");

                        //hämtar varje tabellrad för sig
                        while (reader.Read())
                        {
                            //hämtar och lägger till uthyrningen i return-listan.
                            Rental rental = new Rental();
                            rental.RentalID = reader.GetInt32(rentalIDIndex);
                            rental.MovieID = reader.GetInt32(movieIDIndex);
                            rental.MovieTitle = reader.GetString(titleIndex);
                            rental.CustomerID = reader.GetInt32(customerIDIndex);
                            rental.firstName = reader.GetString(firstNameIndex);
                            rental.lastName = reader.GetString(lastNameIndex);
                            rental.RentalDate = reader.GetDateTime(rentalDateindex).ToString();


                            rentals.Add(rental);
                        }
                    }
                }
                //tar bort ev. tomma poster från listan
                rentals.TrimExcess();
                return rentals.AsEnumerable();
            }

            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //Hämta en uthyrning med specificerat ID
        public Rental getRentalByID(int rentalID)
        {
            try
            {
                Rental rental = new Rental();

                //Anslutningen som ska användas
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getRentalByIDCmd = new SqlCommand("appSchema.usp_getUthyrningByID", conn);
                    getRentalByIDCmd.CommandType = CommandType.StoredProcedure;

                    getRentalByIDCmd.Parameters.Add("@UthyrningID", SqlDbType.Int, 4).Value = rentalID;

                    //anslutningen öppnas
                    conn.Open();

                    using (SqlDataReader reader = getRentalByIDCmd.ExecuteReader())
                    {
                        //hämta alla index i tabeller
                        int rentalIDIndex = reader.GetOrdinal("UthyrningID");
                        int movieIDIndex = reader.GetOrdinal("FilmID");
                        int titleIndex = reader.GetOrdinal("Titel");
                        int customerIDIndex = reader.GetOrdinal("KundID");
                        int firstNameIndex = reader.GetOrdinal("Förnamn");
                        int lastNameIndex = reader.GetOrdinal("Efternamn");
                        int rentalDateindex = reader.GetOrdinal("HyrDatum");

                        if (reader.Read())
                        {
                            rental.RentalID = reader.GetInt32(rentalIDIndex);
                            rental.MovieID = reader.GetInt32(movieIDIndex);
                            rental.MovieTitle = reader.GetString(titleIndex);
                            rental.CustomerID = reader.GetInt32(customerIDIndex);
                            rental.firstName = reader.GetString(firstNameIndex);
                            rental.lastName = reader.GetString(lastNameIndex);
                            rental.RentalDate = reader.GetDateTime(rentalDateindex).ToString();

                            
                        }
                    }
                }
                return rental;
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }



        //funktion som lägger till en ny uthyrning 
        public int NewRental(Rental newRental)
        {
            try
            {
                //Anslutningen som används för att kommunicera med databasen
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand newRentalCmd = new SqlCommand("appSchema.usp_newUthyrning", conn);
                    newRentalCmd.CommandType = CommandType.StoredProcedure;

                    //Parametrar som måste fyllas i
                    newRentalCmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = newRental.MovieID;
                    newRentalCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = newRental.CustomerID;
                    newRentalCmd.Parameters.Add("@HyrDatum", SqlDbType.SmallDateTime, 4).Value = newRental.RentalDate;

                    //en out-parameter med uthyrningens id som den får när den skapas
                    newRentalCmd.Parameters.Add("@UthyrningID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen
                    conn.Open();

                    //Den lagrade proceduren anropas och lägger till den nya uthyrningen i databasen
                    newRentalCmd.ExecuteNonQuery();

                    //Den nya uthyrningens id hämtas och returneras.
                    newRental.CustomerID = (int)newRentalCmd.Parameters["@UthyrningID"].Value;

                    //returnerar det nya id:t. Är 0 Ifall uthyrningen inte lades till
                    return newRental.RentalID;
                }
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //funktion som uppdaterar en befintlig uthyrning
        public int UpdateRental(Rental updRental)
        {
            try
            {
                //anslutningen som används för att kommunicera med databasen.
                using(SqlConnection conn = CreateConnection())
                {
                    //Den lagrade proceduren som ska användas
                    SqlCommand updateRentalCmd = new SqlCommand("appSchema.usp_updateUthyrning", conn);
                    updateRentalCmd.CommandType = CommandType.StoredProcedure;

                    //parametrar till proceduren
                    updateRentalCmd.Parameters.Add("@UthyrningID", SqlDbType.Int, 4).Value = updRental.RentalID;
                    updateRentalCmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = updRental.MovieID;
                    updateRentalCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = updRental.CustomerID;
                    updateRentalCmd.Parameters.Add("@HyrDatum", SqlDbType.SmallDateTime, 4).Value = updRental.RentalDate;                 

                    conn.Open();

                    //kör proceduren och returnerar antalet ändrade rader
                    return updateRentalCmd.ExecuteNonQuery();
                }

            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //funktion som tar bort en uthyrning med medskickat id
        public int DeleteRental(int delRentalID)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand deleteRentalCmd = new SqlCommand("appSchema.usp_deleteUthyrning", conn);
                    deleteRentalCmd.CommandType = CommandType.StoredProcedure;

                    //UthyrningID till uthyrningen som ska raderas skickas som parameter
                    deleteRentalCmd.Parameters.Add("@UthyrningID", SqlDbType.Int, 4).Value = delRentalID;

                    conn.Open();

                    //Kör proceduren som tar bort uthyrningen och returnerar antalet ändrade rader.
                    return deleteRentalCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }
    }
}
