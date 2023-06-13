using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookingClient.Models;

namespace BookingClient.Pages
{
    public partial class OrdersPage : Page
    {
        private bool DlgMode = false;

        public OrdersPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            TourComboBox.ItemsSource = SourceCore.entities.tours.ToList();
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

        public void DlgLoad(bool DlgStatus)
        {
            if (DlgStatus)
            {
                RecordChangeBlock.MinWidth = 230;
                RecordChangeBlock.Width = new GridLength(230);
                DialogGridSplitter.Visibility = Visibility.Visible;
            }
            else
            {
                //RecordChangeBlock.MinWidth = 0;
                //RecordChangeBlock.Width = new GridLength(0);
                //DialogGridSplitter.Visibility = Visibility.Collapsed;
                DlgMode = false;
            }

            RecordsDataGrid.IsHitTestVisible = !DlgStatus;
            FilterTextBox.IsEnabled = !DlgStatus;
            FilterComboBox.IsEnabled = !DlgStatus;
            AddRecordButton.IsEnabled = !DlgStatus;
            CopyRecordButton.IsEnabled = !DlgStatus;
            EditRecordButton.IsEnabled = !DlgStatus;
            DeleteRecordButton.IsEnabled = !DlgStatus;
        }

        private void TransferRecords()
        {
            var SelectedRecord = (orders)RecordsDataGrid.SelectedItem;
            ContactPhoneTextBox.Text = SelectedRecord.contact_phone.ToString();
            TourComboBox.SelectedItem = SelectedRecord.departures.tours;
            DateTourComboBox.SelectedItem = SelectedRecord.departures;
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordChangeTitle.Content = "Добавление";
            DlgMode = true;
            RecordsDataGrid.SelectedItem = null;
            ContactPhoneTextBox.Text = "";
            DlgLoad(true);
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                RecordChangeTitle.Content = "Копирование";
                DlgMode = true;
                TransferRecords();
                DlgLoad(true);
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
                RecordChangeTitle.Content = "Редактирование";
                TransferRecords();
                DlgLoad(true);
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

            if (DlgMode)
            {
                NewRecord.contact_phone = Convert.ToInt64(ContactPhoneTextBox.Text);
                NewRecord.departures = (departures)DateTourComboBox.SelectedItem;
                SourceCore.entities.orders.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (orders)RecordsDataGrid.SelectedItem;
                ChangingRecord.contact_phone = Convert.ToInt64(ContactPhoneTextBox.Text);
                ChangingRecord.departures = (departures)DateTourComboBox.SelectedItem;
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
            List<string> Columns = new List<string>();
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
                //case 2:
                    //RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.persons.Count().ToString().Contains(textbox)).ToList();
                    //break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.departures.tours.tour_name.Contains(textbox)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.departures.date_begin.ToString().Contains(textbox)).ToList();
                    break;
                case 4:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.orders.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
