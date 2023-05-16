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
using BookingClient.Models;


namespace BookingClient.PagesOnWindow
{
    public partial class PersonsAddingPage : Page
    {
        private decimal TotalPrice = 0;
        private int TotalPlace = 0;
        private List<List<string>> RoomList = new List<List<string>>(); 
        private int DepartureId = 0;

        private List<List<string>> PersonList = new List<List<string>>();

        public PersonsAddingPage(decimal TotalPrice, int TotalPlace,  List<List<string>> RoomList, int DepartureId)
        {
            InitializeComponent();
            this.TotalPrice = TotalPrice;
            this.TotalPlace = TotalPlace;
            this.RoomList = RoomList;
            this.DepartureId = DepartureId;
            NeedPersonsTextBox.Text = TotalPlace.ToString();
        }

        private void CommitSelectingRoomsButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommitSelectingRoomsButton.Content.ToString() == "Оформить заказ")
            {
                // Добавление заказа
                orders NewOrder = new orders
                {
                    departures_id = DepartureId,
                    person_count = TotalPlace,
                    price = TotalPrice
                };
                SourceCore.entities.orders.Add(NewOrder);
                SourceCore.entities.SaveChanges();

                // Добавление комнат
                foreach (var item in RoomList)
                {
                    order_rooms NewOrderRoom  = new order_rooms
                    {
                        orders = NewOrder,
                        room_id = Convert.ToInt32(item[0]),
                        room_count = Convert.ToInt32(item[1])
                    };
                    SourceCore.entities.order_rooms.Add(NewOrderRoom);
                    SourceCore.entities.SaveChanges();
                }

                // Добавление туристов
                foreach (List<string> item in PersonList)
                {
                    string BufLastName = item[0];
                    string BufFirstName = item[1];
                    DateTime BufDateOfBirth = Convert.ToDateTime(item[2]);

                    last_names LastName = new last_names();
                    first_names FirstName = new first_names();

                    last_names CurrentLastName = SourceCore.entities.last_names.Where(U => U.last_name == BufLastName).FirstOrDefault();
                    if (CurrentLastName == null)
                    {
                        last_names NewLastName = new last_names();
                        NewLastName.last_name = BufLastName;
                        SourceCore.entities.last_names.Add(NewLastName);
                        SourceCore.entities.SaveChanges();
                        LastName = NewLastName;
                    }
                    else
                    {
                        LastName = CurrentLastName;
                    }

                    first_names CurrentFirstName = SourceCore.entities.first_names.Where(U => U.first_name == BufFirstName).FirstOrDefault();
                    if (CurrentFirstName == null)
                    {
                        first_names NewFirstName = new first_names();
                        NewFirstName.first_name = BufFirstName;
                        SourceCore.entities.first_names.Add(NewFirstName);
                        SourceCore.entities.SaveChanges();
                        FirstName = NewFirstName;
                    }
                    else
                    {
                        FirstName = CurrentFirstName;
                    }

                    persons NewPerson = new persons
                    {
                        orders = NewOrder,
                        last_names = LastName,
                        first_names = FirstName,
                        birthday = BufDateOfBirth,
                    };
                    SourceCore.entities.persons.Add(NewPerson);
                    SourceCore.entities.SaveChanges();
                }
            }
            else
            {
                List<string> Person = new List<string>();
                Person.Add(LastName.Text); // 0
                Person.Add(FirstName.Text); // 1
                Person.Add(DateOfBrithDatePicker.Text); // 2
                PersonList.Add(Person);

                PersonListBox.ItemsSource = PersonList.ToList();

                NeedPersonsTextBox.Text = (TotalPlace - PersonListBox.Items.Count).ToString();

                if (NeedPersonsTextBox.Text == "0")
                {
                    CommitSelectingRoomsButton.Content = "Оформить заказ";
                }
                else
                {
                    CommitSelectingRoomsButton.Content = "Добавить";
                }
            }
        }

        private void RoomCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
