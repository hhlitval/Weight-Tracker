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
    public class DbWeightStatistics : DbConnection
    {
        public ObservableCollection<DailyWeight> LoadData(DateTime startDate, DateTime endDate)
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
                    command.CommandText = @"SELECT Day, Weight 
                                            FROM TotalWeight 
                                                WHERE Day between @FROMDATE and @TODATE 
                                                ORDER BY Day";

                    command.Parameters.Add("@FROMDATE", System.Data.SqlDbType.DateTime2).Value = startDate;
                    command.Parameters.Add("@TODATE", System.Data.SqlDbType.DateTime2).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dbWeightList.Add(new DailyWeight() { Date = (DateTime)reader[0], Weight = (float)reader[1]});
                    }
                    reader.Close();

                    return dbWeightList;
                }
            }
        }
    }
}
