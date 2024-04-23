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

namespace Weight_Tracker.Views
{    
    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(InfoCard));

        public bool IsPositive
        {
            get { return (bool)GetValue(IsPositiveProperty); }
            set { SetValue(IsPositiveProperty, value); }
        }


        public static readonly DependencyProperty IsPositiveProperty =
            DependencyProperty.Register("IsPositive", typeof(bool), typeof(InfoCard));
        

        public string Difference
        {
            get { return (string)GetValue(DifferenceProperty); }
            set { SetValue(DifferenceProperty, value); }
        }

        public static readonly DependencyProperty DifferenceProperty =
            DependencyProperty.Register("Difference", typeof(string), typeof(InfoCard));
    }
}
