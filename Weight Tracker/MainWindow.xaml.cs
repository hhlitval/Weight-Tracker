using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using Weight_Tracker.Models;
using Weight_Tracker.ViewModels;
using Weight_Tracker.Views;

namespace Weight_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime startDate = Date.startDate;
        private DateTime endDate = Date.endDate;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new DashboardViewModel(
                new DailyStatisticsViewModel(startDate, endDate),
                new MonthlyStatisticsViewModel(),
                new InfoCardViewModel(),
                new BmiViewModel());
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

        private void ThisWeekButtonClick(object sender, RoutedEventArgs e)
        {            
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(Date.WeekAgo, Date.Today);
        }

        private void ThisMonthButtonClick(object sender, RoutedEventArgs e)
        {            
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(startDate, endDate);
        }

        private void ThisYearButtonClick(object sender, RoutedEventArgs e)
        {
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(
                Date.YearAgo, Date.Today);
        }

        private void CustomButtonClick(object sender, RoutedEventArgs e)
        {
            CustomDateSelection dateSelectionWindow = new CustomDateSelection();
            Main_Window.Effect = new BlurEffect();
            dateSelectionWindow.DataChanged += OnCustomDate_DataChanged;
            dateSelectionWindow.ShowDialog();
            Main_Window.Effect = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewWeight addNewWeight = new AddNewWeight();
            Main_Window.Effect = new BlurEffect();
            addNewWeight.DataChanged += AddWeight_DataChanged;
            addNewWeight.ShowDialog();    
            Main_Window.Effect = null;
        }

        private void AddWeight_DataChanged(object sender, EventArgs e)
        {
            DataContext = new DashboardViewModel(
                new DailyStatisticsViewModel(startDate, endDate),
                new MonthlyStatisticsViewModel(),
                new InfoCardViewModel(),
                new BmiViewModel());
        }

        private void OnCustomDate_DataChanged(DateTime start, DateTime end)
        {
            dailyStatisticsLineChart.DataContext = new DailyStatisticsViewModel(
                start, end);
        }
    }
}