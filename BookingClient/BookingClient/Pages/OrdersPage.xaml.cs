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
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        //описание вспомогательных переменных
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;

        public OrdersPage()
        {
            InitializeComponent();
            DataContext = this;
            RecordsDataGrid.ItemsSource = SourceCore.entities.orders.ToList();
            TourComboBox.ItemsSource = SourceCore.entities.tours.ToList();
            DateTourComboBox.ItemsSource = SourceCore.entities.departures.ToList();
        }

        public void CarNumDlgLoad(bool b)
        {
            if (b == true)
            {
                RecordChangeBlock.Width = new GridLength(230);
                //Включаем кнопки
                RecordsDataGrid.IsHitTestVisible = false;
                AddRecordButton.IsEnabled = false;
                CopyRecordButton.IsEnabled = false;
                EditRecordButton.IsEnabled = false;
                DeleteRecordButton.IsEnabled = false;
            }
            else
            {
                RecordChangeBlock.Width = new GridLength(0);
                //Выключаем кнопки
                RecordsDataGrid.IsHitTestVisible = true;
                AddRecordButton.IsEnabled = true;
                CopyRecordButton.IsEnabled = true;
                EditRecordButton.IsEnabled = true;
                DeleteRecordButton.IsEnabled = true;
                DlgMode = -1;
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            CarNumDlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            ContactPhoneTextBox.Text = "";
            PersonCountTextBox.Text = "";
            PriceTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                CarNumDlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = ContactPhoneTextBox.Text;
                buf2 = PersonCountTextBox.Text;
                buf3 = PriceTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                ContactPhoneTextBox.Text = buf1;
                PersonCountTextBox.Text = buf2;
                PriceTextBox.Text = buf3;
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
                CarNumDlgLoad(true);
                RecordChangeTitle.Content = "Редактирование";
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

        private void CommitChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(RecordChangeTitle.Content) == "Добавление")
            {
                var NewOrders = new orders();
                NewOrders.contact_phone = Convert.ToInt64(ContactPhoneTextBox.Text);
                NewOrders.person_count = Convert.ToInt32(PersonCountTextBox.Text);
                NewOrders.departures.tours = (tours)TourComboBox.SelectedItem;
                NewOrders.departures = (departures)TourComboBox.SelectedItem;
                NewOrders.price = Convert.ToDecimal(PriceTextBox.Text);
                SourceCore.entities.orders.Add(NewOrders);
            }
            SourceCore.entities.SaveChanges();

            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            CarNumDlgLoad(false);

        }

        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            CarNumDlgLoad(false);
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
