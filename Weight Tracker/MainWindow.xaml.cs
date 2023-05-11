using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weight_Tracker.ViewModels;

namespace Weight_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime startDate = new DateTime(2022, 10, 17).AddDays(-30);
        private DateTime endDate = new DateTime(2022, 10, 17);
        
        public MainWindow()
        {
            InitializeComponent();

            
            DataContext = new DailyStatisticsViewModel(startDate, endDate);
            DataContext = new MonthlyStatisticsViewModel();
            DataContext = new BmiViewModel();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void thisWeekButtonClick(object sender, RoutedEventArgs e)
        {
            endDate = new DateTime(2022, 10, 17);
            startDate = endDate.AddDays(-4);
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(startDate, endDate);
        }

        private void thisMonthButtonClick(object sender, RoutedEventArgs e)
        {            
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(startDate, endDate);
        }

        private void thisYearButtonClick(object sender, RoutedEventArgs e)
        {
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(
                new DateTime(2022, 10, 17).AddDays(-30),
                new DateTime(2022, 10, 17));
        }

        private void customButtonClick(object sender, RoutedEventArgs e)
        {
            DatePickerWindow datePickerWindow = new DatePickerWindow();
            datePickerWindow.Show();
        }
    }
}
