using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weight_Tracker.UserControls
{
    /// <summary>
    /// Interaction logic for BarChart.xaml
    /// </summary>
    public partial class BarChart : UserControl
    {
        public BarChart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                           Values = new ChartValues<double> { 79.2, 78.8, 79.0, 78.7, 76.6, 74.9, 74.1, 73.3, 73.5, 73.5, 74.0, 73.1, 74.4 }
                        }
                    };            

            Labels = new[] { "Mar 22", "Apr 22", "May 22", "Jun 22", "Jul 22", "Aug 22", "Sep 22", "Oct 22", "Nov 22", "Dec 22", "Jan 23", "Feb 23", "Mar 23", };
            Formatter = value => value.ToString("N1");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}

     
