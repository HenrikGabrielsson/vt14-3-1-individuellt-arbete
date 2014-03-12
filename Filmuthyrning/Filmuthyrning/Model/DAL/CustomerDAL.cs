using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Filmuthyrning.Model.BLL;


namespace Filmuthyrning.Model.DAL
{
    public class CustomerDAL : DALBase
    {
        //Hämtar alla kunder från tabellen.
        public IEnumerable<Customer> getCustomers()
        {
            try
            {
                //här ska alla kunder från databasen sparas
                List<Customer> customers = new List<Customer>(500);

                //en anslutning till databasen hämtas.
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getCustomersCmd = new SqlCommand("appSchema.usp_getKunder", conn);
                    getCustomersCmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = getCustomersCmd.ExecuteReader())
                    {

                        //hämta alla index i tabeller
                        int customerIDIndex = reader.GetOrdinal("KundID");
                        int customerTypeIDindex = reader.GetOrdinal("KundtypID");
                        int fNameIndex = reader.GetOrdinal("Förnamn");
                        int lNameIndex = reader.GetOrdinal("Efternamn");
                        int phoneNumberIndex = reader.GetOrdinal("Telefon");
                        int emailIndex = reader.GetOrdinal("Email");

                        //hämtar varje tabellrad för sig
                        while (reader.Read())
                        {
                            //hämtar och lägger till kunden i return-listan.
                            Customer customer = new Customer();
                            customer.CustomerID = reader.GetInt32(customerIDIndex);
                            customer.CustomerTypeID = reader.GetByte(customerTypeIDindex);
                            customer.FirstName = reader.GetString(fNameIndex);
                            customer.LastName = reader.GetString(lNameIndex);
                            customer.PhoneNumber = reader.GetString(phoneNumberIndex);
                            if(!reader.IsDBNull(emailIndex)) //kollar så email inte är null för att undvika exception
                            {
                                customer.Email = reader.GetString(emailIndex);
                            }

                            customers.Add(customer);
                        }
                    }
                }

                //tar bort ev. tomma poster från listan
                customers.TrimExcess();
                return customers.AsEnumerable();
            }

            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //Hämta en kund med specificerat ID
        public Customer getCustomerByID(int customerID)
        {
            try
            {
                Customer customer = new Customer();

                //Anslutningen som ska användas
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand getCustomerByIDCmd = new SqlCommand("appSchema.usp_getKundByID", conn);
                    getCustomerByIDCmd.CommandType = CommandType.StoredProcedure;

                    getCustomerByIDCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = customerID;

                    //anslutningen öppnas
                    conn.Open();

                    using (SqlDataReader reader = getCustomerByIDCmd.ExecuteReader())
                    {
                        //hämta alla index i tabeller
                        int customerIDIndex = reader.GetOrdinal("KundID");
                        int customerTypeIDindex = reader.GetOrdinal("KundtypID");
                        int fNameIndex = reader.GetOrdinal("Förnamn");
                        int lNameIndex = reader.GetOrdinal("Efternamn");
                        int phoneNumberIndex = reader.GetOrdinal("Telefon");
                        int emailIndex = reader.GetOrdinal("Email");

                        //hämtar tabellraden med samma ID som argumentet till funktionen 
                        if (reader.Read())
                        {
                            customer.CustomerID = reader.GetInt32(customerIDIndex);
                            customer.CustomerTypeID = reader.GetByte(customerTypeIDindex);
                            customer.FirstName = reader.GetString(fNameIndex);
                            customer.LastName = reader.GetString(lNameIndex);
                            customer.PhoneNumber = reader.GetString(phoneNumberIndex);
                            if (!reader.IsDBNull(emailIndex)) //kollar så email inte är null för att undvika exception
                            {
                                customer.Email = reader.GetString(emailIndex);
                            }

                            return customer;
                        }
                    }
                }
                //Om ingen kund hämtades så returneras bara null
                return null;
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //funktion som lägger till en ny kund 
        public int NewCustomer(Customer newCustomer)
        {
            try
            {
                //Anslutningen som används för att kommunicera med databasen
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand newCustomerCmd = new SqlCommand("appSchema.usp_newKund", conn);
                    newCustomerCmd.CommandType = CommandType.StoredProcedure;

                    //Parametrar som måste fyllas i
                    newCustomerCmd.Parameters.Add("@FNamn", SqlDbType.VarChar, 50).Value = newCustomer.FirstName;
                    newCustomerCmd.Parameters.Add("@ENamn", SqlDbType.VarChar, 50).Value = newCustomer.LastName;
                    newCustomerCmd.Parameters.Add("@Telefon", SqlDbType.VarChar, 10).Value = newCustomer.PhoneNumber;

                    //en out-parameter med kundens id som den får när den skapas
                    newCustomerCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutningen
                    conn.Open();

                    //Den lagrade proceduren anropas och lägger till den nya kunden i databasen
                    newCustomerCmd.ExecuteNonQuery();

                    //Den nya kundens id hämtas och returneras.
                    newCustomer.CustomerID = (int)newCustomerCmd.Parameters["@KundID"].Value;

                    //returnerar det nya id:t. Är 0 Ifall kunden inte lades till
                    return newCustomer.CustomerID;

                }
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //funktion som uppdaterar en befintlig kund
        public int UpdateCustomer(Customer updCustomer)
        {
            try
            {
                //anslutningen som används för att kommunicera med databasen.
                using(SqlConnection conn = CreateConnection())
                {
                    //Den lagrade proceduren som ska användas
                    SqlCommand updateCustomerCmd = new SqlCommand("appSchema.usp_updateKund", conn);
                    updateCustomerCmd.CommandType = CommandType.StoredProcedure;

                    //parametrar till proceduren
                    updateCustomerCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = updCustomer.CustomerID;
                    updateCustomerCmd.Parameters.Add("@FNamn", SqlDbType.VarChar, 50).Value = updCustomer.FirstName;
                    updateCustomerCmd.Parameters.Add("@ENamn", SqlDbType.VarChar, 50).Value = updCustomer.LastName;
                    updateCustomerCmd.Parameters.Add("@Telefon", SqlDbType.VarChar, 10).Value = updCustomer.PhoneNumber;
                    updateCustomerCmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = updCustomer.Email;                    

                    conn.Open();

                    //kör proceduren och returnerar antalet ändrade rader
                    return updateCustomerCmd.ExecuteNonQuery();
                    
                }

            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }

        //funktion som tar bort en kund med medskickat id
        public int DeleteCustomer(int delCustomerID)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    //den lagrade proceduren som ska användas
                    SqlCommand deleteCustomerCmd = new SqlCommand("appSchema.usp_deleteKund", conn);
                    deleteCustomerCmd.CommandType = CommandType.StoredProcedure;

                    //kundID till kunden som ska raderas skickas som parameter
                    deleteCustomerCmd.Parameters.Add("@KundID", SqlDbType.Int, 4).Value = delCustomerID;

                    conn.Open();

                    //Kör proceduren som tar bort kunden och returnerar antalet ändrade rader.
                    return deleteCustomerCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new ApplicationException("An error occurred when accessing the database.");
            }
        }
    }
}