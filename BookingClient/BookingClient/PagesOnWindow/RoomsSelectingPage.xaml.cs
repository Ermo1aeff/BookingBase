using BookingClient.Models;
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

namespace BookingClient.PagesOnWindow
{
    public partial class RoomsSelectingPage : Page
    {
        private List<List<string>> RoomList = new List<List<string>>();
        private decimal TotalPrice = 0;
        private int TotalPlace = 0;
        public RoomsSelectingPage(int DepartureId)
        {
            InitializeComponent();

            var Departure = SourceCore.entities.departures.Where(U => U.departure_id == DepartureId).FirstOrDefault();
            RoomListBox.ItemsSource = SourceCore.entities.rooms.Where(U => U.tour_id == Departure.tour_id).ToList();
        }

        private void RoomCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            PropertyInfo pi = comboBox.DataContext.GetType().GetProperty("room_id");
            var RoomId = Convert.ToInt32(pi.GetValue(comboBox.DataContext, null));
            rooms Room = SourceCore.entities.rooms.Where(U => U.room_id == RoomId).FirstOrDefault();

            TotalPrice = 0;
            TotalPlace = 0;

            List<string> RoomL = new List<string>();
            bool flag = false;

            for (int i = 0; i < RoomList.Count; i++)
            {
                if (RoomList[i][0] == Room.room_id.ToString())
                {
                    RoomList[i][1] = comboBox.SelectedIndex.ToString();
                    RoomList[i][5] = (Room.beds_count * comboBox.SelectedIndex).ToString();
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                RoomL.Add(Room.room_id.ToString()); // 0
                RoomL.Add(comboBox.SelectedIndex.ToString()); // 1
                RoomL.Add(Room.price.ToString()); // 2
                RoomL.Add(Room.room_name); // 3
                RoomL.Add(Room.beds_count.ToString()); // 4
                RoomL.Add((Room.beds_count * comboBox.SelectedIndex).ToString()); // 5
                RoomList.Add(RoomL);
            }

            for (int i = 0; i < RoomList.Count; i++)
            {
                TotalPrice += Convert.ToDecimal(RoomList[i][2]) * Convert.ToInt32(RoomList[i][1]);
                TotalPlace += Convert.ToInt32(RoomList[i][1]) * Convert.ToInt32(RoomList[i][4]);
            }
            PriceBreakdownListBox.ItemsSource = RoomList.Where(U => U[1] != "0");
            TotalDueTextBox.Text = TotalPrice.ToString();
        }

        private void CommitSelectingRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PersonsAddingPage(TotalPrice, TotalPlace, RoomList));
        }
    }
}
