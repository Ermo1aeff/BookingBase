using BookingClient.Models;
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

namespace BookingClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderRoomsPage.xaml
    /// </summary>
    public partial class OrderRoomsPage : Page
    {
        private string buf1;
        public OrderRoomsPage()
        {
            InitializeComponent();
            DataContext = this;
            RecordsDataGrid.ItemsSource = SourceCore.entities.order_rooms.ToList();
            OrderIdComboBox.ItemsSource = SourceCore.entities.orders.ToList();
            RoomNameComboBox.ItemsSource = SourceCore.entities.rooms.ToList();

            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            RecordsDataGrid.ItemsSource = SourceCore.entities.order_rooms.ToList();
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
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            RoomCountTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = RoomCountTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                RoomCountTextBox.Text = buf1;
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
                SourceCore.entities.order_rooms.Remove((order_rooms)RecordsDataGrid.SelectedItem);
                SourceCore.entities.SaveChanges();
                UpdateDataGrid();
            }
        }

        private void CommitChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(RecordChangeTitle.Content) == "Добавление")
            {
                var NewRecord = new order_rooms();
                NewRecord.orders = (orders)OrderIdComboBox.SelectedItem;
                NewRecord.rooms = (rooms)RoomNameComboBox.SelectedItem;
                NewRecord.room_count = Convert.ToInt32(RoomCountTextBox.Text);
                SourceCore.entities.order_rooms.Add(NewRecord);
            }
            SourceCore.entities.SaveChanges();

            UpdateDataGrid();
            DlgLoad(false);
        }

        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(false);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Columns = new List<string>();
            int DataGridItemsCount = RecordsDataGrid.Columns.Count;
            for (int I = 0; I < DataGridItemsCount; I++)
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
            string Filter = FilterTextBox.Text;
            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.order_rooms.Where(filtercase => filtercase.order_room_id.ToString().Contains(Filter)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.order_rooms.Where(filtercase => filtercase.rooms.room_name.ToString().Contains(Filter)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.order_rooms.Where(filtercase => filtercase.room_count.ToString().Contains(Filter)).ToList();
                    break;
            }
        }
    }
}
