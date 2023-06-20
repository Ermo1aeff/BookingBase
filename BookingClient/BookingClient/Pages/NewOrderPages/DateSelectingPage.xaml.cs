using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Data;
using System.Reflection;

namespace BookingClient.PagesOnWindow
{
    [ValueConversion(typeof(int), typeof(departures))]
    public class DateEndConverter : IValueConverter
    {
        public double MinimumCostRichCar { get; set; }
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            departures CurrentDeparture = SourceCore.entities.departures.FirstOrDefault(filtercase => filtercase.departure_id == (int)value);

            double DayCount = (double)CurrentDeparture.tours.day_count;
            DateTime DateBegin = (DateTime)CurrentDeparture.date_begin;
            return DateBegin.AddDays(DayCount);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            departures CurrentDeparture = SourceCore.entities.departures.FirstOrDefault(filtercase => filtercase.departure_id == (int)value);
            return CurrentDeparture;
        }
    }

    public partial class DateSelectingPage : Page
    {
        private List<byte[]> ImageList = new List<byte[]>();

        private int ImageIndex = 0;

        public DateSelectingPage(int TourId, int AccountId)
        {
            InitializeComponent();

            ImageList = (
                from item in SourceCore.entities.images
                where item.tour_id == TourId
                select item.img).ToList();

            TourImage.Source = ToImage(ImageList[ImageIndex]);

            DeparturesListBox.ItemsSource = SourceCore.entities.departures.Where(filtercase => filtercase.tour_id == TourId && filtercase.date_begin >= DateTime.Today).ToList();
            tours Tour = SourceCore.entities.tours.Where(U => U.tour_id == TourId).FirstOrDefault();

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
            AgeTextBlock.Text = "От " + Tour.min_age.ToString() + " до " + Tour.max_age;
            TourIdTextBlock.Text = Tour.tour_id.ToString();
            TourPriceTextBlock.Text = Tour.price.ToString();

            viewed_tours DelViewedTour = SourceCore.entities.viewed_tours.SingleOrDefault(U => U.account_id == AccountId && U.tour_id == TourId);
            if (DelViewedTour != null)
            {
                SourceCore.entities.viewed_tours.Remove(DelViewedTour);
            }

            viewed_tours NewViewedTour = new viewed_tours();
            NewViewedTour.account_id = AccountId;
            NewViewedTour.tour_id = TourId;

            SourceCore.entities.viewed_tours.Add(NewViewedTour);

            SourceCore.entities.SaveChanges();
        }

        private void CommitDepartureButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            PropertyInfo pi = button.DataContext.GetType().GetProperty("departure_id");
            int DepartureId = Convert.ToInt32(pi.GetValue(button.DataContext, null));
            NavigationService.Navigate(new RoomsSelectingPage(DepartureId));
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            ImageIndex = ImageIndex < ImageList.Count - 1 ? ImageIndex + 1 : 0;
            TourImage.Source = ToImage(ImageList[ImageIndex]);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ImageIndex = ImageIndex > 0 ? ImageIndex - 1 : ImageList.Count - 1;
            TourImage.Source = ToImage(ImageList[ImageIndex]);
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
