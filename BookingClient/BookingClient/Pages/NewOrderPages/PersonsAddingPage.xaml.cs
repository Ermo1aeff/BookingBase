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
    public partial class PersonsAddingPage : Page
    {
        public PersonsAddingPage(decimal TotalPrice, int TotalPlace,  List<List<string>> RoomList)
        {
            InitializeComponent();
            PersonListBox.ItemsSource = SourceCore.entities.persons.ToList();
            NeedPersonsTextBox.Text = TotalPlace.ToString();
        }

        private void CommitSelectingRoomsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RoomCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
