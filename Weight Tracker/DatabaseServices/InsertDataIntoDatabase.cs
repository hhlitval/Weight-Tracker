using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Tracker.DatabaseServices
{
    /// <summary>
    /// Insert weight data into the database
    /// </summary>
    public class InsertDataIntoDatabase : DbConnection
    {
        public void InsertData(DateTime date, string value)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO TotalWeight (Date, Weight) VALUES (@Date, @Value)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
