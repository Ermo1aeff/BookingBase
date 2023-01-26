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

namespace BookingClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateOrdersPage.xaml
    /// </summary>
    public partial class CreateOrdersPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private int OrderID;
        public CreateOrdersPage()
        {
            InitializeComponent();
            DataContext = this;
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            //PersonsDataGrid.ItemsSource = SourceCore.entities.persons.ToList();
            //FirstNameComboBox.ItemsSource = SourceCore.entities.first_names.ToList();
            //LastNameComboBox.ItemsSource = SourceCore.entities.last_names.ToList();
            CreateOrderGrid.Visibility = Visibility.Visible;
            PersonChangeGrid.Visibility = Visibility.Collapsed;
        }
        public void DlgLoad(bool b)
        {
            if (b == true)
            {
                RecordChangeBlock.Width = new GridLength(230);
                //Включаем кнопки
                RecordsDataGrid.IsHitTestVisible = false;
                //AddRecordButton.IsEnabled = false;
                //CopyRecordButton.IsEnabled = false;
                //EditRecordButton.IsEnabled = false;
                //DeleteRecordButton.IsEnabled = false;
            }
            else
            {
                RecordChangeBlock.Width = new GridLength(0);
                //Выключаем кнопки
                RecordsDataGrid.IsHitTestVisible = true;
                //AddRecordButton.IsEnabled = true;
                //CopyRecordButton.IsEnabled = true;
                //EditRecordButton.IsEnabled = true;
                //DeleteRecordButton.IsEnabled = true;
                DlgMode = -1;
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            //RecordChangeTitle.Content = "Добавление";
            ContactPhoneTextBox.Text = "";
            PersonCountTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                //RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = ContactPhoneTextBox.Text;
                buf2 = PersonCountTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                ContactPhoneTextBox.Text = buf1;
                PersonCountTextBox.Text = buf2;
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        private void EditRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                //RecordChangeTitle.Content = "Редактирование";
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки!", "Сообщение", MessageBoxButton.OK);
            }
        }

        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                SourceCore.entities.tours.Remove((tours)RecordsDataGrid.SelectedItem);
                SourceCore.entities.SaveChanges();
                RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            }
        }

        private void ContinueRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            var NewOrders = new orders();
            NewOrders.contact_phone = Convert.ToInt64(ContactPhoneTextBox.Text);
            NewOrders.person_count = Convert.ToInt32(PersonCountTextBox.Text);
            NewOrders.departures = (departures)DateTourComboBox.SelectedItem;
            SourceCore.entities.orders.Add(NewOrders);
            SourceCore.entities.SaveChanges();
            OrderID = NewOrders.order_id;
            PersonsDataGrid.Visibility = Visibility.Visible;
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            CreateOrderGrid.Visibility = Visibility.Collapsed;
            RecordsDataGrid.Visibility = Visibility.Collapsed;
            PersonsDataGrid.Visibility = Visibility.Visible;
            PersonChangeGrid.Visibility = Visibility.Visible;
        }

        private void CommitPersonCommitButton_Click(object sender, RoutedEventArgs e)
        {
            var NewPersons = new persons();
            NewPersons.order_id = OrderID;
            NewPersons.passport = Convert.ToInt64(PassportTextBox.Text);
            NewPersons.birthday = Convert.ToDateTime(BirthdayTextBox.Text);
            SourceCore.entities.persons.Add(NewPersons);
            SourceCore.entities.SaveChanges();
            PersonsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.order_id.ToString().Contains(OrderID.ToString())).ToList();
        }


        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(false);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int I = 0; I < 6; I++)
            {
                Columns.Add(RecordsDataGrid.Columns[I].Header.ToString());
            }
            FilterComboBox.ItemsSource = Columns;
            FilterComboBox.SelectedIndex = 0;
            //foreach (DataGridColumn Column in RecordsDataGrid.Columns)
            //{
            //    Column.CanUserSort = false;
            //}

        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            var textbox = FilterTextBox.Text;
            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.tour_name.Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.tour_description.Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                    //case 3:
                    //    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.max_group_size.ToString().Contains(textbox)).ToList();
                    //    break;
            }
        }


    }

}

