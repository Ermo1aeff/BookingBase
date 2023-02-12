using BookingClient.Models;
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

namespace BookingClient.PagesOnWindow
{
    public partial class DateSelectingPage : Page
    {
        public DateSelectingPage(int TourId)
        {
            InitializeComponent();
            DepartureListBox.ItemsSource = SourceCore.entities.departures.ToList();
        }

        private void DepartureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommitDepartureButton.IsEnabled = true;
            var sdfsd = (departures)DepartureListBox.SelectedItem;
        }

        private void DepartureListBox_Selected(object sender, RoutedEventArgs e)
        {
            //CommitDepartureButton.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("LightGreen");
        }
    }
}
