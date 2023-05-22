﻿using LiveCharts;
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
        public double MonthAverage { get; set; }
        public double MonthDifference { get; set; }
        public bool IsPositiveMonthDifference { get; set; }

        public MonthlyStatisticsViewModel()
        {
            IEnumerable<DailyWeight> weight = new LoadAverageDataFromDB(_yearAgo, _today).WeightStatistics;

            MonthlyWeightValues = new ChartValues<double>(weight.Select(w => w.Weight));
            MonthAndYear = weight.Select(c => (c.Date).ToString("MMM yyyy")).ToArray();
            BarFormatter = value => value.ToString("F1");
            MonthAverage = weight.Select(w => w.Weight).Last();
            MonthDifference = MonthAverage - (weight.ElementAt(weight.Count() - 2).Weight);
            IsPositiveMonthDifference = MonthDifference  >= 0 ? false : true;
        }
    }
}
