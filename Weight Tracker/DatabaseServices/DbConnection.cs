﻿using System.Data.SqlClient;


namespace Weight_Tracker.DatabaseServices
{
    /// <summary>
    /// Database connection to MS SQL Server
    /// </summary>
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = "Server=(local); DataBase=WeightData; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}