using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.Models;

namespace Weight_Tracker.DbConnection
{
    public class DatabaseMonthlyStatistics : DbConnection
    {       
        public ObservableCollection<MonthlyWeight> LoadData()
        {
            var dbWeightList = new ObservableCollection<MonthlyWeight>();            

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT FORMAT ( Day , 'MMM yyyy' ) as Dates, AVG(Weight) as AverageWeight
                                            FROM TotalWeight
                                            WHERE Day between @FROMDATE and @TODATE
                                            GROUP BY FORMAT ( Day , 'MMM yyyy' )";
                    
                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = DateTime.Now.AddDays(-365);
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = DateTime.Now;

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dbWeightList.Add(new MonthlyWeight() { Date = (string)reader[0], Weight = (double)reader[1]});
                    }
                    reader.Close();

                    return dbWeightList;
                }
            }
        }
    }
}
