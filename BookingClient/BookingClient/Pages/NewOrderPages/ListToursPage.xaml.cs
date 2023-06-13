using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BookingClient.Models;
using BookingClient.PagesOnWindow;

namespace BookingClient.Pages.NewOrderPages
{
    public partial class ListToursPage : Page
    {

        private int AccountID;

        public ListToursPage(int AccountId)
        {
            InitializeComponent();
            DataContext = this;
            AccountID = AccountId;

            accounts AccountProfile = SourceCore.entities.accounts.SingleOrDefault(U => U.account_id == AccountId);


            TourListBox.ItemsSource =
                (from em in SourceCore.entities.tours
                 select new
                 {
                     TourName = em.tour_name,
                     PricePerDay = Math.Round((double)(em.price / em.day_count)),
                     Price = Math.Round((double)em.price),
                     DayCount = em.day_count,
                     em.tour_id,
                     BeginCity = em.cities.city_name,
                     EndCity = em.cities1.city_name,
                     TourImage = em.images.FirstOrDefault(U => U.tour_id == em.tour_id),
                     LikedCheck = em.liked_tours.FirstOrDefault(U => U.account_id == AccountId).tour_id == em.tour_id
                 }).ToList();
        }

        private void ViewTourButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            PropertyInfo pi = button.DataContext.GetType().GetProperty("tour_id");
            int TourId = Convert.ToInt32(pi.GetValue(button.DataContext, null));
            NavigationService.Navigate(new DateSelectingPage(TourId, AccountID));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            PropertyInfo pi = checkBox.DataContext.GetType().GetProperty("tour_id");
            int TourId = Convert.ToInt32(pi.GetValue(checkBox.DataContext, null));

            liked_tours NewLikedTour = new liked_tours();

            NewLikedTour.account_id = AccountID;
            NewLikedTour.tour_id = TourId;
            SourceCore.entities.liked_tours.Add(NewLikedTour);
            SourceCore.entities.SaveChanges();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            PropertyInfo pi = checkBox.DataContext.GetType().GetProperty("tour_id");
            int TourId = Convert.ToInt32(pi.GetValue(checkBox.DataContext, null));

            liked_tours DelLikedTour = SourceCore.entities.liked_tours.SingleOrDefault(U => U.account_id == AccountID && U.tour_id == TourId);
            SourceCore.entities.liked_tours.Remove(DelLikedTour);
            SourceCore.entities.SaveChanges();
        }
    }
}
