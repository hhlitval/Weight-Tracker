using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using Weight_Tracker.Models;

namespace Weight_Tracker.DatabaseServices
{
    public class LoadAverageDataFromDB : DbConnection
    { 
        public ObservableCollection<DailyWeight> WeightStatistics { get; set; }
        
        public LoadAverageDataFromDB(DateTime start, DateTime end)
        {
            WeightStatistics = LoadData(start, end);
        }

        private ObservableCollection<DailyWeight> LoadData(DateTime startDate, DateTime endDate)
        {
            var dbWeightList = new ObservableCollection<DailyWeight>();            
            
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get all data from database
                    command.CommandText = @"SELECT FORMAT(Date, 'MMM yyyy') AS month_year,
                                            CAST(ROUND(AVG(Weight),1)AS DECIMAL(3,1)) AS average_value
                                            FROM TotalWeight
                                            WHERE Date between @FROMDATE and @TODATE
                                            GROUP BY FORMAT(Date, 'MMM yyyy')
                                            ORDER BY MIN(Date)";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dbWeightList.Add(new DailyWeight() { Date = DateTime.ParseExact((string)reader[0], "MMM yyyy", CultureInfo.InvariantCulture), Weight = (decimal)reader[1]}); 
                    }
                    reader.Close();

                    return dbWeightList;
                }
            }
        }        
    }
}
