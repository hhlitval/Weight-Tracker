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
    public class DailyStatisticsViewModel : BaseViewModel
    {
        private readonly DatabaseDailyStatistics _weightStatisticsService = new DatabaseDailyStatistics();
        
        public ChartValues<float>? WeightValues { get; set; }
        public string[]? Days { get; set; }

        public Func<float, string>? LineFormatter { get; private set; }

        public DailyStatisticsViewModel(DateTime startDate, DateTime endDate)
        {
            IEnumerable<DailyWeight> weight = _weightStatisticsService.LoadData(startDate, endDate);

            WeightValues = new ChartValues<float>(weight.Select(w => w.Weight));
            Days = weight.Select(c => (c.Date).ToString("dd.MM.yy")).ToArray();
            LineFormatter = value => value.ToString("N1");
        }
    }
}
