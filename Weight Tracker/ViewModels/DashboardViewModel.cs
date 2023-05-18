using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Tracker.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DailyStatisticsViewModel DailyStatisticsViewModel { get; }
        public MonthlyStatisticsViewModel MonthlyStatisticsViewModel { get; }
        public InfoCardViewModel InfoCardViewModel { get; }
        public BmiViewModel BmiViewModel { get; }

        public DashboardViewModel(DailyStatisticsViewModel dailyStatisticsViewModel, MonthlyStatisticsViewModel monthlyStatisticsViewModel, InfoCardViewModel infoCardViewModel, BmiViewModel bmiViewModel)
        {
            DailyStatisticsViewModel = dailyStatisticsViewModel;
            MonthlyStatisticsViewModel = monthlyStatisticsViewModel;
            InfoCardViewModel = infoCardViewModel;
            BmiViewModel = bmiViewModel;
        }
    }
}
