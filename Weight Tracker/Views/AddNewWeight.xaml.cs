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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Weight_Tracker.DatabaseServices;

namespace Weight_Tracker.Views
{
    /// <summary>
    /// Interaction logic for AddNewWeight.xaml
    /// </summary>
    public partial class AddNewWeight : Window
    {
        private readonly InsertDataIntoDatabase insertNewWeight = new ();
        public AddNewWeight()
        {
            InitializeComponent();            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate ?? DateTime.Today;
            string enteredValue = textBox.Text;
            insertNewWeight.InsertData(selectedDate, enteredValue);
            Close();
        }

        private void Calendar_GotMouseCapture(object sender, MouseEventArgs e)
        {
            UIElement? originalElement = e.OriginalSource as UIElement;
            if (originalElement is CalendarDayButton || originalElement is CalendarItem)
            {
                originalElement.ReleaseMouseCapture();
            }        
        }        
    }
}
