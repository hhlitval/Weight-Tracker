using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.DatabaseServices;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{
    public class CurrentBmiViewModel : BaseViewModel
    {        
        public decimal CurrentBmiValue { get; set; }
        public string? WeightValuation { get; set; }

        public CurrentBmiViewModel()
        {
            CurrentBmiValue = new MonthlyStatisticsViewModel().MonthAverage;
            WeightValuation = GetBmiResultValuation() ?? "Not correct value";
        }

        private string? GetBmiResultValuation()
        {
            if (CurrentBmiValue >= 50 && CurrentBmiValue <= (decimal)72.3)
                return "You are a healthy weight!";
            else if (CurrentBmiValue > (decimal)72.3 && CurrentBmiValue <= 87)
                return "You are overweight!!";
            else
                return "You are obese !!!";
        }
    }
}
