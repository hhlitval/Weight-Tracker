using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weight_Tracker.ViewModels;

namespace Weight_Tracker.Views
{
    /// <summary>
    /// Interaction logic for CustomDateSelection.xaml
    /// </summary>
    public partial class CustomDateSelection : Window
    {
        public delegate void DataChangedEventHandler(DateTime start, DateTime end);

        public event DataChangedEventHandler? DataChanged;

        public CustomDateSelection()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = calendar1.SelectedDate ?? DateTime.Today;
            DateTime end = calendar2.SelectedDate ?? DateTime.Today;
            DataChangedEventHandler? handler = DataChanged;
            if (handler != null)
            {
                handler(start, end);
            }
            this.Close();
        }

        private void calendar_GotMouseCapture(object sender, MouseEventArgs e)
        {
            UIElement? originalElement = e.OriginalSource as UIElement;
            if (originalElement is CalendarDayButton || originalElement is CalendarItem)
            {
                originalElement.ReleaseMouseCapture();
            }
        }
    }
}
