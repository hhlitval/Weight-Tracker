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
        public static readonly DateTime Yesterday = Today.AddDays(-1);
        public static readonly DateTime DayBeforeYesterday = Today.AddDays(-2);
        public static readonly DateTime WeekAgo = Today.AddDays(-7);
        public static readonly DateTime MonthAgo = Today.AddDays(-30);
        public static readonly DateTime YearAgo = Today.AddDays(-365);

        public static readonly DateTime DefaultStartDate = Today.AddDays(-Today.Day);
        public static readonly DateTime DefaultEndDate = Today;        
    }
}
