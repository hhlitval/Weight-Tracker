using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Tracker.DbConnection;
using Weight_Tracker.Models;

namespace Weight_Tracker.ViewModels
{
    class BmiViewModel
    {
        public double BmiValue { get; set; }       

        public BmiViewModel()
        {
            BmiValue = new InfoCardViewModel().TodayWeight;
        }
    }
}
