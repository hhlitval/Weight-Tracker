﻿using LiveCharts;
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
        private readonly DateTime _today = Date.Today;
        private readonly DateTime _yesterday = Date.Yesterday;

        public double TodayWeight { get; set; }
        public double TodayDifference { get; set; }
        public bool IsPositiveToday { get; set; }
        public double YesterdayWeight { get; set; }
        public double YesterdayDifference { get; set; }
        public bool IsPositiveYesterday { get; set; }
        public double MonthAverageWeight { get; set; }

        public InfoCardViewModel()
        {
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(_yesterday, _today).WeightStatistics;
            
            TodayWeight = (from v in weight where v.Date == _today select v.Weight).FirstOrDefault();
            YesterdayWeight = (from v in weight where v.Date == _yesterday select v.Weight).FirstOrDefault();
            IsPositiveToday = (TodayDifference = TodayWeight - YesterdayWeight) >= 0 ? false :  true;
            IsPositiveYesterday = (YesterdayDifference = YesterdayWeight - 75) >= 0 ? false : true;
        }        
    }
}
