using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.DatabaseServices;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{
    public class InfoCardsViewModel : BaseViewModel
    {        
        private readonly DateTime _today = Date.Today;
        private readonly DateTime _yesterday = Date.Yesterday;
        private readonly DateTime _dayBeforeYesterday = Date.DayBeforeYesterday;

        public decimal TodayWeight { get; set; }
        public decimal TodayDifference { get; set; }
        public bool IsPositiveToday { get; set; }
        public bool IsNeutral { get; set; }
        public decimal YesterdayWeight { get; set; }
        public decimal YesterdayDifference { get; set; }
        public bool IsPositiveYesterday { get; set; }

        public InfoCardsViewModel()
        {
            decimal dayBeforeYesterdayWeight = default;
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(_dayBeforeYesterday, _today).WeightStatistics;
            
            TodayWeight = (from v in weight where v.Date == _today select v.Weight).FirstOrDefault();
            YesterdayWeight = (from v in weight where v.Date == _yesterday select v.Weight).FirstOrDefault();
            dayBeforeYesterdayWeight = (from v in weight where v.Date == _dayBeforeYesterday select v.Weight).FirstOrDefault();
            IsPositiveToday = (TodayDifference = TodayWeight - YesterdayWeight) > 0 ? false : true;
            IsPositiveYesterday = (YesterdayDifference = YesterdayWeight - dayBeforeYesterdayWeight) > 0 ? false : true;
        }     
        
        
    }
}
