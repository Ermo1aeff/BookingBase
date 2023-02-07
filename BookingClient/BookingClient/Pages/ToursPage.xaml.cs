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
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;
        private string buf4;
        private string buf5;
        private string buf6;
        private string buf7;

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

        public void DlgLoad(bool b)
        {
            if (b)
            {
                RecordChangeBlock.MinWidth = 230;
                RecordChangeBlock.Width = new GridLength(230);
                //Выключаем элементы управления
                RecordsDataGrid.IsHitTestVisible = false;
                FilterTextBox.IsEnabled = false;
                FilterComboBox.IsEnabled = false;
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
                //Включаем элементы управления
                RecordsDataGrid.IsHitTestVisible = true;
                FilterTextBox.IsEnabled = true;
                FilterComboBox.IsEnabled = true;
                AddRecordButton.IsEnabled = true;
                CopyRecordButton.IsEnabled = true;
                EditRecordButton.IsEnabled = true;
                DeleteRecordButton.IsEnabled = true;
                DialogGridSplitter.Visibility = Visibility.Collapsed;
                DlgMode = -1;
            }
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            TourNameTextBox.Text = "";
            TourDescriptionTextBox.Text = "";
            BeginCityComboBox.Text = "";
            EndCityTextBox.Text = "";
            PriceTextBox.Text = "";
            DayCountTextBox.Text = "";
            MaxGroupSizeTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = TourNameTextBox.Text;
                buf2 = TourDescriptionTextBox.Text;
                buf3 = BeginCityComboBox.Text;
                buf4 = EndCityTextBox.Text;
                buf5 = PriceTextBox.Text;
                buf6 = DayCountTextBox.Text;
                buf7 = MaxGroupSizeTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                TourNameTextBox.Text = buf1;
                TourDescriptionTextBox.Text = buf2;
                BeginCityComboBox.Text = buf3;
                EndCityTextBox.Text = buf4;
                PriceTextBox.Text = buf5;
                DayCountTextBox.Text = buf6;
                MaxGroupSizeTextBox.Text = buf7;
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
            NewRecord.tour_name = TourNameTextBox.Text;
            NewRecord.tour_description = TourDescriptionTextBox.Text;
            NewRecord.cities = (cities)BeginCityComboBox.SelectedItem;
            NewRecord.cities1 = (cities)EndCityTextBox.SelectedItem;
            NewRecord.price = Convert.ToDecimal(PriceTextBox.Text);
            NewRecord.day_count = Convert.ToInt32(DayCountTextBox.Text);
            NewRecord.max_group_size = Convert.ToInt32(MaxGroupSizeTextBox.Text);

            if (DlgMode == 0)
            {
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
    }
}
