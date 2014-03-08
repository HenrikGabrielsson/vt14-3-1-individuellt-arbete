using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Filmuthyrning.Model.DAL
{
    public abstract class DALBase
    {
        //anslutning till databasen
        private static string _connectionString;

        //konstruktor
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["MovieRentalConnectionString"].ConnectionString;
        }

        //Funktion som returnerar anslutningssträngen
        protected SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            return conn;
        }



    }
}