using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using Weight_Tracker.DbConnection;
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
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(_yearAgo, _today).WeightStatistics;

            MonthlyWeightValues = new ChartValues<double>(weight.Select(w => w.Weight));
            MonthAndYear = weight.Select(c => (c.Date).ToString("dd.MM.yy")).ToArray();
            BarFormatter = value => value.ToString("F1");
        }
    }
}
