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
    /// Interaction logic for LineChart.xaml
    /// </summary>
    public partial class LineChart : UserControl
    {
        public LineChart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Weight =",
                    Values = new ChartValues<double> {73.6, 73.2, 73.1, 73.1, 73.7, 74.1, 73.9, 73.5, 
                        73.5, 74.5, 73.9, 73.5, 73.5, 74.5, 74.5, 74.7, 74.8, 74.8, 74.9, 74.9, 75.0, 
                        75.1, 75.3, 75.1, 74.9, 75.2, 75.2, 74.9, 74.8, 75.4, 75.4}
                },
            };

            Labels = new[] { "1 Mar", "2 Mar", "3 Mar", "4 Mar", "5 Mar", "6 Mar", "7 Mar",
            "8 Mar","9 Mar","10 Mar","11 Mar","12 Mar","13 Mar","14 Mar","15 Mar","16 Mar",
            "17 Mar","18 Mar","19 Mar","20 Mar","21 Mar","22 Mar","23 Mar","24 Mar","25 Mar",
            "26 Mar","27 Mar","28 Mar","29 Mar","30 Mar","31 Mar"};
            YFormatter = value => value.ToString("N1");
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}