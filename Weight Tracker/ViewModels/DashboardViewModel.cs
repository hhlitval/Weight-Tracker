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
        public InfoCardsViewModel InfoCardsViewModel { get; }
        public CurrentBmiViewModel CurrentBmiViewModel { get; }

        public DashboardViewModel(DailyStatisticsViewModel dailyStatisticsViewModel, MonthlyStatisticsViewModel monthlyStatisticsViewModel, InfoCardsViewModel infoCardViewModel, CurrentBmiViewModel bmiViewModel)
        {
            DailyStatisticsViewModel = dailyStatisticsViewModel;
            MonthlyStatisticsViewModel = monthlyStatisticsViewModel;
            InfoCardsViewModel = infoCardViewModel;
            CurrentBmiViewModel = bmiViewModel;
        }
    }
}
