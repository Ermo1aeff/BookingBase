using BookingClient.PagesOnWindow;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BookingClient.Windows;
using BookingClient.Models;
using System.IO;
using System.ComponentModel;

namespace BookingClient.Pages
{
    //[ValueConversion(typeof(int), typeof(departures))]
    //public class DateEndConverter : IValueConverter
    //{
    //    public double MinimumCostRichCar { get; set; }
    //    public object Convert(object value, Type targetType, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        departures CurrentDeparture = SourceCore.entities.departures.FirstOrDefault(filtercase => filtercase.departure_id == (int)value);

    //        double DayCount = (double)CurrentDeparture.tours.day_count;
    //        DateTime DateBegin = (DateTime)CurrentDeparture.date_begin;
    //        return DateBegin.AddDays(DayCount);
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter,
    //        System.Globalization.CultureInfo culture)
    //    {
    //        departures CurrentDeparture = SourceCore.entities.departures.FirstOrDefault(filtercase => filtercase.departure_id == (int)value);
    //        return CurrentDeparture;
    //    }
    //}

    public partial class ProfilePage : Page
    {
        private int _AccountID;

        public int AccountID 
        { 
            get
            {
                return _AccountID;
            }
            set 
            {
                _AccountID = value;
            }
        }

        public ProfilePage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        public static Visual GetDescendantByType(Visual element, Type type)
        {
            if (element == null)
            {
                return null;
            }

            if (element.GetType() == type)
            {
                return element;
            }

            Visual foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType(visual, type);
                if (foundElement != null)
                {
                    break;
                }
            }

            return foundElement;
        }

        private void ViewedTourListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetDescendantByType((ListBox)sender, typeof(ScrollViewer)) as ScrollViewer;
            scrollViewer?.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
        }

        private void LikedTourListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetDescendantByType((ListBox)sender, typeof(ScrollViewer)) as ScrollViewer;
            scrollViewer?.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
        }

        private void PassedTourListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetDescendantByType((ListBox)sender, typeof(ScrollViewer)) as ScrollViewer;
            scrollViewer?.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
        }

        private void TOTourListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetDescendantByType((ListBox)sender, typeof(ScrollViewer)) as ScrollViewer;
            scrollViewer?.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
        }

        private void TransparentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            PropertyInfo pi = button.DataContext.GetType().GetProperty("tour_id");
            var TourId = Convert.ToInt32(pi.GetValue(button.DataContext, null));

            switch (SourceCore.entities.accounts.FirstOrDefault(U => U.account_id == _AccountID).role_id)
            {
                case 1:
                    break;
                case 2:

                    break;
                case 3:
                    NavigationService.Navigate(new TOTourListPage(TourId, AccountID));
                    break;
                case 4:
                    NavigationService.Navigate(new DateSelectingPage(TourId, AccountID));
                    break;
                default:
                    break;
            }

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ProfileDlgWindow ProfileDlgWin = new ProfileDlgWindow(AccountID);

            accounts Account = SourceCore.entities.accounts.FirstOrDefault(U => U.account_id == AccountID);

            if (ProfileDlgWin.ShowDialog() == true)
            {
                SetAccountInfo();
                (Tag as MainWindow).SetAccountCaption(Account.account_id);
            }
        }

        public void SetAccountInfo()
        {
            accounts Account = SourceCore.entities.accounts.FirstOrDefault(U => U.account_id == AccountID);

            if (Account.image != null)
            {
                AvatarImageBrush.ImageSource = ToImage(Account.image);
            }

            if (Account.last_names != null)
            {
                ProfileCaptionTextBlock.Text = $"Привет {Account.first_names.first_name} {Account.last_names.last_name}!";
            }
            else
            {
                ProfileCaptionTextBlock.Text = $"Тур оператор {Account.first_names.first_name}";
            }

            if (Account.email != null)
            {
                EmailTextBlock.Text = Account.email;
            } 
            else
            {
                EmailTextBlock.Text = "Почта еще не добавлена";
            }

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SetAccountInfo();

            switch (SourceCore.entities.accounts.FirstOrDefault(U => U.account_id == _AccountID).role_id)
            {
                case 1:
                    break;
                case 2:

                    break;
                case 3:
                    TOToursStackPanel.Visibility = Visibility.Visible;
                    break;
                case 4:
                    CustomerToursStackPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

            ViewedTourListBox.ItemsSource = (
                from item in SourceCore.entities.viewed_tours
                where item.account_id == _AccountID
                select new
                {
                    TourName = item.tours.tour_name,
                    Price = Math.Round((double)item.tours.price),
                    DayCount = item.tours.day_count,
                    item.tour_id,
                    TourImage = item.tours.images.FirstOrDefault(filtercase => filtercase.tour_id == item.tour_id)
                }).ToList();

            LikedTourListBox.ItemsSource = (
                from item in SourceCore.entities.liked_tours
                where item.account_id == _AccountID
                select new
                {
                    TourName = item.tours.tour_name,
                    Price = Math.Round((double)item.tours.price),
                    DayCount = item.tours.day_count,
                    item.tour_id,
                    TourImage = item.tours.images.FirstOrDefault(filtercase => filtercase.tour_id == item.tour_id)
                }).ToList();

            PassedTourListBox.ItemsSource = (
                from item in SourceCore.entities.passed_tours
                where item.account_id == _AccountID
                select new
                {
                    TourName = item.tours.tour_name,
                    Price = Math.Round((double)item.tours.price),
                    DayCount = item.tours.day_count,
                    item.tour_id,
                    TourImage = item.tours.images.FirstOrDefault(filtercase => filtercase.tour_id == item.tour_id)
                }).ToList();

            TOTourListBox.ItemsSource = (
                from item in SourceCore.entities.tours
                where item.account_id == _AccountID
                select new
                {
                    TourName = item.tour_name,
                    Price = Math.Round((double)item.price),
                    DayCount = item.day_count,
                    item.tour_id,
                    TourImage = item.images.FirstOrDefault(filtercase => filtercase.tour_id == item.tour_id)
                }).ToList();
        }
    }
}
