using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            UpdateDataGrid(null);
            TourComboBox.ItemsSource = SourceCore.entities.tours.ToList();
        }

        public void DlgLoad(bool b)
        {
            if (b == true)
            {
                RecordChangeBlock.MinWidth = 230;
                RecordChangeBlock.Width = new GridLength(230);
                //Включаем кнопки
                RecordsDataGrid.IsHitTestVisible = false;
                AddRecordButton.IsEnabled = false;
                CopyRecordButton.IsEnabled = false;
                EditRecordButton.IsEnabled = false;
                DeleteRecordButton.IsEnabled = false;
                DialogGridSplitter.Visibility = Visibility.Visible;
            }
            else
            {
                RecordChangeBlock.MinWidth = 0;
                RecordChangeBlock.Width = new GridLength(0);
                //Выключаем кнопки
                RecordsDataGrid.IsHitTestVisible = true;
                AddRecordButton.IsEnabled = true;
                CopyRecordButton.IsEnabled = true;
                EditRecordButton.IsEnabled = true;
                DeleteRecordButton.IsEnabled = true;
                DialogGridSplitter.Visibility = Visibility.Collapsed;
                DlgMode = -1;
            }
        }

        public void UpdateDataGrid(orders SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (orders)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<orders>(SourceCore.entities.orders.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }


        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            ContactPhoneTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = ContactPhoneTextBox.Text;
                buf2 = TourComboBox.Text;
                buf3 = DateTourComboBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                ContactPhoneTextBox.Text = buf1;
                TourComboBox.Text = buf2;
                DateTourComboBox.Text = buf3;
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
                try
                {
                    var DeletingRecord = (orders)RecordsDataGrid.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (RecordsDataGrid.SelectedIndex < RecordsDataGrid.Items.Count - 1)
                    {
                        RecordsDataGrid.SelectedIndex++;
                    }
                    else
                    {
                        if (RecordsDataGrid.SelectedIndex > 0)
                        {
                            RecordsDataGrid.SelectedIndex--;
                        }
                    }

                    var SelectingRecord = (orders)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.orders.Remove(DeletingRecord);
                    SourceCore.entities.SaveChanges();
                    UpdateDataGrid(SelectingRecord);
                }
                catch
                {

                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
        }

        private void CommitChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            var NewRecord = new orders();
            NewRecord.contact_phone = Convert.ToInt64(ContactPhoneTextBox.Text);
            NewRecord.person_count = SourceCore.entities.persons.Count(U => U.order_id == 1);

            // Пример SQL запроса (требуется полключение к БД)

            //string connectionSring = @"Data Source=ERMOLAEV;Initial Catalog=Booking_Base;Integrated security=true";
            //SqlConnection sqlConnection = new SqlConnection(connectionSring);
            //sqlConnection.Open();
            //string query = "select count(*) from persons where order_id = 1 group by order_id";
            //SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //int requestbody = 0;
            //while (sqlDataReader.Read())
            //{
            //    requestbody = sqlDataReader.GetInt32(0);
            //}

            //NewOrders.person_count = requestbody;

            NewRecord.person_count = 0;
            NewRecord.departures = (departures)DateTourComboBox.SelectedItem;
            if (DlgMode == 0)
            {
                SourceCore.entities.orders.Add(NewRecord);
            }
            SourceCore.entities.SaveChanges();

            UpdateDataGrid(NewRecord);
            DlgLoad(false);
        }

        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(false);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            int DataGridItemsCount = RecordsDataGrid.Columns.Count;
            for (int I = 0; I < DataGridItemsCount; I++)
            {
                Columns.Add(RecordsDataGrid.Columns[I].Header.ToString());
            }
            FilterComboBox.ItemsSource = Columns;
            FilterComboBox.SelectedIndex = 0;
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.departures.tour_id.ToString().Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.contact_phone.ToString().Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.person_count.ToString().Contains(textbox)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.departures.tours.tour_name.Contains(textbox)).ToList();
                    break;
                case 4:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.departures.date_begin.ToString().Contains(textbox)).ToList();
                    break;
                case 5:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
