using BookingClient.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class CitiesPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;

        public CitiesPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            CountryNameComboBox.ItemsSource = SourceCore.entities.countries.ToList();
        }

        public void UpdateDataGrid(cities SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (cities)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<cities>(SourceCore.entities.cities.ToList());
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
            CountryNameComboBox.Text = "";
            CityNameTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = CountryNameComboBox.Text;
                buf2 = CityNameTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                CountryNameComboBox.Text = buf1;
                CityNameTextBox.Text = buf2;
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
                    var DeletingRecord = (cities)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (cities)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.cities.Remove(DeletingRecord);
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
            var NewRecord = new cities();
            NewRecord.countries = (countries)CountryNameComboBox.SelectedItem;
            NewRecord.city_name = CityNameTextBox.Text;

            if (DlgMode == 0)
            {

                SourceCore.entities.cities.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (cities)RecordsDataGrid.SelectedItem;
                ChangingRecord.countries = (countries)CountryNameComboBox.SelectedItem;
                ChangingRecord.city_name = CityNameTextBox.Text;
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
            string Filter = FilterTextBox.Text;
            switch (FilterComboBox.SelectedIndex)
            {
                case 0:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.cities.Where(filtercase => filtercase.countries.country_name.Contains(Filter)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.cities.Where(filtercase => filtercase.city_name.ToString().Contains(Filter)).ToList();
                    break;
            }
        }
    }
}
