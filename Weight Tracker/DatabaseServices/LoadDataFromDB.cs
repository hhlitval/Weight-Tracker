using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Weight_Tracker.Models;

namespace Weight_Tracker.DatabaseServices
{
    public class LoadDataFromDB : DbConnection
    { 
        public ObservableCollection<DailyWeight> WeightStatistics { get; set; }
        
        public LoadDataFromDB(DateTime start, DateTime end)
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
                    command.CommandText = @"SELECT Date, Weight
                                            FROM TotalWeight 
                                                WHERE Date between @FROMDATE and @TODATE 
                                                ORDER BY Date";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dbWeightList.Add(new DailyWeight() { Date = (DateTime)reader["Date"], Weight = (decimal)reader["Weight"]});
                    }
                    reader.Close();

                    return dbWeightList;
                }
            }
        }        
    }
}
