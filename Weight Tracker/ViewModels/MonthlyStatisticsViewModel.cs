using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.DbConnection;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{    
    public class MonthlyStatisticsViewModel
    {
        private readonly DatabaseMonthlyStatistics _weightStatisticsService = new DatabaseMonthlyStatistics();
        public ChartValues<double>? MonthlyWeightValues { get; set; }
        public string[]? MonthYear { get; set; }
        public Func<float, string>? LineFormatter { get; private set; }

        public MonthlyStatisticsViewModel()
        {
            IEnumerable<MonthlyWeight> weight = _weightStatisticsService.LoadData();

            MonthlyWeightValues = new ChartValues<double>(weight.Select(w => w.Weight));
            MonthYear = weight.Select(c => c.Date).ToArray();
            LineFormatter = value => value.ToString("N1");
        }
    }
}
