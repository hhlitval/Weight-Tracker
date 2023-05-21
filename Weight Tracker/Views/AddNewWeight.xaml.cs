﻿using System;
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
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler? DataChanged;

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
            DataChangedEventHandler? handler = DataChanged;
            InsertDataIntoDatabase insertNewWeight = new();
            string enteredValue = textBox.Text;
            DateTime selectedDate = calendar.SelectedDate ?? DateTime.Today;
            insertNewWeight.InsertData(selectedDate, enteredValue);

            if (handler != null)
            {
                handler(this, new EventArgs());
            }            
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
