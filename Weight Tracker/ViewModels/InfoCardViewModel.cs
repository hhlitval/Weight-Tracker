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
    public class InfoCardViewModel : BaseViewModel
    {
        private readonly DatabaseDailyStatistics _weightStatisticsService = new DatabaseDailyStatistics();
        private readonly DateTime todayDate = DateTime.Today;
        private readonly DateTime yesterdayDate = DateTime.Today.AddDays(-1);

        public double TodayWeight { get; set; }
        public double TodayDifference { get; set; }
        public bool IsPositiveToday { get; set; }

        public double YesterdayWeight { get; set; }
        public double YesterdayDifference { get; set; }
        public bool IsPositiveYesterday { get; set; }


        public double MonthAverageWeight { get; set; }

        public InfoCardViewModel()
        {
            IEnumerable<DailyWeight> weight = _weightStatisticsService.LoadData(yesterdayDate, todayDate);
            
            TodayWeight = (from v in weight where v.Date == todayDate select v.Weight).FirstOrDefault();
            YesterdayWeight = (from v in weight where v.Date == yesterdayDate select v.Weight).FirstOrDefault();
            IsPositiveToday = (TodayDifference = TodayWeight - YesterdayWeight) > 0 ? false :  true;
            IsPositiveYesterday = (YesterdayDifference = YesterdayWeight - 75) > 0 ? false : true;
        }        
    }
}
