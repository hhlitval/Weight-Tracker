using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight_Tracker.Models
{
    public static class Date
    {
        public static readonly DateTime Today = DateTime.Today;
        public static readonly DateTime Yesterday = DateTime.Today.AddDays(-1);
        public static readonly DateTime WeekAgo = DateTime.Today.AddDays(-7);
        public static readonly DateTime MonthAgo = DateTime.Today.AddDays(-30);
        public static readonly DateTime YearAgo = DateTime.Today.AddDays(-365);


        public static readonly DateTime startDate = new DateTime(2022, 10, 17).AddDays(-30);
        public static readonly DateTime endDate = new DateTime(2022, 10, 17);
        
        
    }
}
