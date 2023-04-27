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
            DepartureListBox.ItemsSource = SourceCore.entities.departures.Where(filtercase => filtercase.tour_id == TourId).ToList();
            var Tour = SourceCore.entities.tours.Where(U => U.tour_id == TourId).FirstOrDefault();
            TourNameTextBlock.Text = Tour.tour_name;
            DayCountTextBlick.Text = Tour.day_count.ToString();
            if (Tour.city_begin_id == Tour.city_end_id)
            {
                BeginAndEndIsDifferentStackPnanel.Visibility = Visibility.Collapsed;
                BeginAndEndIsIdenticalStackPanel.Visibility = Visibility.Visible;
                BeginAndEndTextBlock.Text = Tour.cities.city_name + ", " + Tour.cities.countries.country_name;
            }
            else
            {
                BeginAndEndIsDifferentStackPnanel.Visibility = Visibility.Visible;
                BeginAndEndIsIdenticalStackPanel.Visibility = Visibility.Collapsed;
                BeginTextBock.Text = Tour.cities.city_name + ", " + Tour.cities.countries.country_name;
                EndTextBlock.Text = Tour.cities1.city_name + ", " + Tour.cities1.countries.country_name;
            }
            MaxGroupSizeTextBlock.Text = Tour.max_group_size.ToString();
            TourIdTextBlock.Text = Tour.tour_id.ToString();
            TourPriceTextBlock.Text = Tour.price.ToString();
        }

        private void DepartureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommitDepartureButton.IsEnabled = true;
        }


        private void CommitDepartureButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedDepartures = (departures)DepartureListBox.SelectedItem;
            NavigationService.Navigate(new RoomsSelectingPage(SelectedDepartures.departure_id));
        }
    }
}
