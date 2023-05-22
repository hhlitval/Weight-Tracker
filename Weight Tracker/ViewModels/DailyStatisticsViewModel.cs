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
        public ChartValues<double>? WeightValues { get; set; }
        public string[]? Days { get; set; }
        public Func<double, string>? LineFormatter { get; private set; }       

        public DailyStatisticsViewModel(DateTime startDate, DateTime endDate)
        {
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(startDate, endDate).WeightStatistics;

            WeightValues = new ChartValues<double>(weight.Select(w => w.Weight));
            Days = weight.Select(c => (c.Date).ToString("dd.MM.yy")).ToArray();
            LineFormatter = value => value.ToString("F1");            
        }        
    }
}
