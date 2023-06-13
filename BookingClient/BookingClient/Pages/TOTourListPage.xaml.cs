using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookingClient.Pages
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

    [ValueConversion(typeof(int), typeof(int))]
    public class PersonCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            int PersonCount = SourceCore.entities.orders.FirstOrDefault(filtercase => filtercase.order_id == (int)value).persons.Count();

            string result = $"{PersonCount} туристов";

            if (!(PersonCount > 5 && PersonCount < 14))
            {
                if (PersonCount % 10 == 1)
                {
                    result = $"{PersonCount} турист";
                }

                if (PersonCount % 10 > 1 && PersonCount % 10 < 5)
                {
                    result = $"{PersonCount} туриста";
                }
            }
            
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public partial class TOTourListPage : Page
    {
        public TOTourListPage()
        {
            InitializeComponent();
            //OrdersListBox.ItemsSource = SourceCore.entities.orders.ToList();
            DeparturesListBox.ItemsSource = SourceCore.entities.departures.ToList();
        }

        private void OrderListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetDescendantByType(OrdersListBox, typeof(ScrollViewer)) as ScrollViewer;
            ListBox listBox = (ListBox)sender;
            scrollViewer?.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
            //if (e.Delta > 0)
            //{
            //    scrollViewer.LineLeft();
            //}
            //else
            //{
            //    scrollViewer.LineRight();
            //}
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }

    
}
