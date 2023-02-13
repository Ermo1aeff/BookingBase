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
        private List<List<int>> RoomList = new List<List<int>>();
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

            List<int> RoomL = new List<int>();
            bool flag = false;

            for (int i = 0; i < RoomList.Count; i++)
            {
                if (RoomList[i][0] == Room.room_id)
                {
                    RoomList[i][1] = comboBox.SelectedIndex;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                RoomL.Add(Room.room_id);
                RoomL.Add(comboBox.SelectedIndex);
                RoomList.Add(RoomL);
            }

            for (int i = 0; i < RoomList.Count; i++)
            {
                int ListRoomId = RoomList[i][0];
                Room = SourceCore.entities.rooms.Where(U => U.room_id == ListRoomId).FirstOrDefault();
                TotalPrice += (decimal)Room.price * RoomList[i][1];
                TotalPlace += RoomList[i][1];
            }
            TotalDueTextBox.Text = TotalPrice.ToString();
        }

        private void CommitSelectingRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PersonsAddingPage(TotalPrice, TotalPlace, RoomList));
        }
    }
}
