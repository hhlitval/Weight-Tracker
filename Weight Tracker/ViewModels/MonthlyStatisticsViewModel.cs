using LiveCharts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Weight_Tracker.DatabaseServices;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{    
    public class MonthlyStatisticsViewModel
    {
        private readonly DateTime _yearAgo = Date.YearAgo;
        private readonly DateTime _today = Date.Today;        
        
        public ChartValues<double>? MonthlyWeightValues { get; set; }
        public string[]? MonthAndYear { get; set; }
        public Func<double, string>? BarFormatter { get; private set; }

        public MonthlyStatisticsViewModel()
        {
            IEnumerable<DailyWeight> weight = new LoadAverageDataFromDB(_yearAgo, _today).WeightStatistics;


         //  var result =  weight.Select(weight => new
         //   {
         //       Dateformat = weight.Date.ToString("MMM yyyy"),
         //       Weight = weight.Weight
         //   })
         //.GroupBy(weight => weight.Dateformat)
         //.Select(group => new DailyWeight
         //{
         //    Date = DateTime.Parse(),
         //    Weight = group.Average(weight => weight.Weight)
         //})
         //.OrderByDescending(item => item.Date);

            MonthlyWeightValues = new ChartValues<double>(weight.Select(w => w.Weight));
            MonthAndYear = weight.Select(c => (c.Date).ToString("MMM yyyy")).ToArray();
            BarFormatter = value => value.ToString("F1");
        }
    }
}
