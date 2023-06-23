using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            for (int i = 0; i < TotalPlace; i++)
            {
                List<string> Person = new List<string>();
                Person.Add("");
                Person.Add("");
                Person.Add("");
                Person.Add("");
                Person.Add((i + 1).ToString());
                PersonList.Add(Person);
            }
            PersonListBox.ItemsSource = PersonList.ToList();
        }

        private void AddPersonAndCommitOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactPhone.Text == "")
            {
                MessageBox.Show("Необходимо указать контактный номер телефона!");
                return;
            }
            foreach (List<string> item in PersonList)
            {
                if (item[0] == "" || item[1] == "" || item[2] == "" || item[3] == "")
                {
                    MessageBox.Show("Данные были заполнены не полностью!");
                    return;
                }
            }
            // Добавление заказа
            orders NewOrder = new orders
            {
                departures_id = DepartureId,
                price = TotalPrice,
                contact_phone = Convert.ToInt64(ContactPhone.Text),
            };
            SourceCore.entities.orders.Add(NewOrder);
            SourceCore.entities.SaveChanges();

            // Добавление комнат
            foreach (var item in RoomList)
            {
                order_rooms NewOrderRoom = new order_rooms
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
                string BufFirstName = item[0];
                string BufLastName = item[1];
                DateTime BufDateOfBirth = Convert.ToDateTime(item[2]);
                long BufPassport = Convert.ToInt64(item[3]);


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
                    passport = BufPassport,
                };
                SourceCore.entities.persons.Add(NewPerson);
                SourceCore.entities.SaveChanges();
            }

            MessageBox.Show("Ваш заказ создан, в ближайшее время к вам обратится ваш тур оператор.");
        }

        private void PassportTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;
        }
    }
}
