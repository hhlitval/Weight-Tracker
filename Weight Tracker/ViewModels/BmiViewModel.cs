using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.DatabaseServices;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{
    public class BmiViewModel : BaseViewModel
    {
        private readonly DateTime _today = Date.Today;
        private readonly DateTime _monthAgo = Date.MonthAgo;
        public double BmiValue { get; set; }       

        public BmiViewModel()
        {
            IEnumerable<DailyWeight> weight = new LoadDataFromDB(_monthAgo, _today).WeightStatistics;

            BmiValue = (from v in weight where v.Date == _today select v.Weight).FirstOrDefault();
        }
    }
}
