using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookingClient.Models;

namespace BookingClient.Pages
{
    public partial class ToursPage : Page
    {
        private bool DlgMode = false;

        public ToursPage()
        {
            InitializeComponent();
            DataContext = this;
            BeginCityComboBox.ItemsSource = SourceCore.entities.cities.ToList();
            EndCityTextBox.ItemsSource = SourceCore.entities.cities.ToList();
            UpdateDataGrid(null);
        }

        public void UpdateDataGrid(tours SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (tours)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<tours>(SourceCore.entities.tours.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }

        public void DlgLoad(bool DlgStatus)
        {
            if (DlgStatus)
            {
                DlgPanel.Visibility = Visibility.Visible;
            }
            else
            {
                DlgPanel.Visibility = Visibility.Collapsed;
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
            var SelectedRecord = (tours)RecordsDataGrid.SelectedItem;
            TourNameTextBox.Text = SelectedRecord.tour_name;
            TourDescriptionTextBox.Text = SelectedRecord.tour_description;
            BeginCityComboBox.SelectedItem = SelectedRecord.cities;
            EndCityTextBox.SelectedItem = SelectedRecord.cities1;
            PriceTextBox.Text = SelectedRecord.price.ToString();
            DayCountTextBox.Text = SelectedRecord.day_count.ToString();
            MaxGroupSizeTextBox.Text = SelectedRecord.max_group_size.ToString();
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordChangeTitle.Content = "Добавление";
            DlgMode = true;
            RecordsDataGrid.SelectedItem = null;
            TourNameTextBox.Text = "";
            TourDescriptionTextBox.Text = "";
            BeginCityComboBox.Text = "";
            EndCityTextBox.Text = "";
            PriceTextBox.Text = "";
            DayCountTextBox.Text = "";
            MaxGroupSizeTextBox.Text = "";
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
                    // Ссылка на удаляемую запись
                    var DeletingRecord = (tours)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (tours)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.tours.Remove(DeletingRecord);
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
            var NewRecord = new tours();

            if (DlgMode)
            {
                NewRecord.tour_name = TourNameTextBox.Text;
                NewRecord.tour_description = TourDescriptionTextBox.Text;
                NewRecord.cities = (cities)BeginCityComboBox.SelectedItem;
                NewRecord.cities1 = (cities)EndCityTextBox.SelectedItem;
                NewRecord.price = Convert.ToDecimal(PriceTextBox.Text);
                NewRecord.day_count = Convert.ToInt32(DayCountTextBox.Text);
                NewRecord.max_group_size = Convert.ToInt32(MaxGroupSizeTextBox.Text);
                SourceCore.entities.tours.Add(NewRecord);
            } 
            else
            {
                var ChangingRecord = (tours)RecordsDataGrid.SelectedItem;
                ChangingRecord.tour_name = TourNameTextBox.Text;
                ChangingRecord.tour_description = TourDescriptionTextBox.Text;
                ChangingRecord.cities = (cities)BeginCityComboBox.SelectedItem;
                ChangingRecord.cities1 = (cities)EndCityTextBox.SelectedItem;
                ChangingRecord.price = Convert.ToDecimal(PriceTextBox.Text);
                ChangingRecord.day_count = Convert.ToInt32(DayCountTextBox.Text);
                ChangingRecord.max_group_size = Convert.ToInt32(MaxGroupSizeTextBox.Text);
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.tour_name.Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.tour_description.Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.cities.city_name.ToString().Contains(textbox)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.cities1.city_name.ToString().Contains(textbox)).ToList();
                    break;
                case 4:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                case 5:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.day_count.ToString().Contains(textbox)).ToList();
                    break;
                case 6:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.max_group_size.ToString().Contains(textbox)).ToList();
                    break;
            }
        }

        private void ChangePanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ChangePanel.ActualWidth < 850)
            {
                AddRecordButton.Style = Resources["AddButton"] as Style;
                CopyRecordButton.Style = Resources["CopyButton"] as Style;
                EditRecordButton.Style = Resources["EditButton"] as Style;
                DeleteRecordButton.Style = Resources["DeleteButton"] as Style;
            }
            else
            {
                AddRecordButton.Style = Resources["DarkStandartButton"] as Style;
                CopyRecordButton.Style = Resources["DarkStandartButton"] as Style;
                EditRecordButton.Style = Resources["DarkStandartButton"] as Style;
                DeleteRecordButton.Style = Resources["DarkStandartButton"] as Style;
            }
        }
    }
}
