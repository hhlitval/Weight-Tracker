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
        
        public ChartValues<decimal>? MonthlyWeightValues { get; set; }
        public string[]? MonthAndYear { get; set; }
        public Func<decimal, string>? BarFormatter { get; private set; }
        public decimal MonthAverage { get; set; }
        public decimal MonthDifference { get; set; }
        public bool IsPositiveMonthDifference { get; set; }

        public MonthlyStatisticsViewModel()
        {
            IEnumerable<DailyWeight> weight = new LoadAverageDataFromDB(_yearAgo, _today).WeightStatistics;

            MonthlyWeightValues = new ChartValues<decimal>(weight.Select(w => w.Weight));
            MonthAndYear = weight.Select(c => (c.Date).ToString("MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"))).ToArray();
            BarFormatter = value => value.ToString("F1");
            MonthAverage = weight.Select(w => w.Weight).Last();
            MonthDifference = MonthAverage - (weight.ElementAt(weight.Count() - 2).Weight);
            IsPositiveMonthDifference = MonthDifference  >= 0 ? false : true;
        }
    }
}
