using LiveCharts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Weight_Tracker.DatabaseServices;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{    
    public class DailyStatisticsViewModel : BaseViewModel
    {        
        public ChartValues<decimal>? WeightValues { get; set; }
        public string[]? Days { get; set; }
        public Func<decimal, string>? LineFormatter { get; private set; }
        public int MinValue { get; set; } 
        public int MaxValue { get; set; }

        public DailyStatisticsViewModel(DateTime startDate, DateTime endDate)
        {
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(startDate, endDate).WeightStatistics;

            WeightValues = new ChartValues<decimal>(weight.Select(w => w.Weight));
            Days = weight.Select(c => (c.Date).ToString("dd.MM.yy")).ToArray();
            LineFormatter = value => value.ToString("D0");
            MinValue = (int)WeightValues.Min() - 1;
            MaxValue = (int)WeightValues.Max() + 1;
        }        
    }
}
