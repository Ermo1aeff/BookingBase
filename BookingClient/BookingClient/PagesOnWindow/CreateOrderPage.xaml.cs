using BookingClient.Models;
using BookingClient.PagesOnWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace BookingClient.PagesForWindow
{
    internal class tourslist
    {
        public string BeginCity { get; set; }
    }

    public partial class CreateOrderPage : Page
    {
        public CreateOrderPage()
        {
            InitializeComponent();
            DataContext = this;

            using (Booking_BaseEntities dw = new Booking_BaseEntities())
            {
                TourListBox.ItemsSource =
                    (from em in dw.tours
                     select new
                     {
                         TourName = em.tour_name,
                         PricePerDay = Math.Round((double)(em.price / em.day_count)),
                         Price = Math.Round((double)em.price),
                         DayCount = em.day_count,
                         em.tour_id,
                         BeginCity = em.cities.city_name,
                         EndCity = em.cities1.city_name,
                         TourImage = em.images.FirstOrDefault(filtercase => filtercase.tour_id == em.tour_id)
                     }).ToList();
            }
        }

        private void ViewTourButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            PropertyInfo pi = button.DataContext.GetType().GetProperty("tour_id");
            var TourId = Convert.ToInt32(pi.GetValue(button.DataContext, null));
            NavigationService.Navigate(new DateSelectingPage(TourId));
        }

        private void TourListBox_MouseMove(object sender, MouseEventArgs e)
        {
            var listbox = (ListBox)sender;
            //listbox.SelectedItem = listbox.SelectionMode;
        }
    }
}
