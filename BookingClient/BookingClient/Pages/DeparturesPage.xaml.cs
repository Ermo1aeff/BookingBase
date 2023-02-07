using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class DeparturesPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;

        public DeparturesPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            TourNameComboBox.ItemsSource = SourceCore.entities.tours.ToList();
        }

        public void UpdateDataGrid(departures SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (departures)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<departures>(SourceCore.entities.departures.ToList());
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
            DateBeginDatePicker.SelectedDate = DateTime.Now;
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = TourNameComboBox.Text;
                buf2 = DateBeginDatePicker.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                TourNameComboBox.Text = buf1;
                DateBeginDatePicker.Text = buf2;
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
                    var DeletingRecord = (departures)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (departures)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.departures.Remove(DeletingRecord);
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
            var NewRecord = new departures();
            NewRecord.tours = (tours)TourNameComboBox.SelectedItem;
            NewRecord.date_begin = DateBeginDatePicker.SelectedDate;

            if (DlgMode == 0)
            {
                SourceCore.entities.departures.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (departures)RecordsDataGrid.SelectedItem;
                ChangingRecord.tours = (tours)TourNameComboBox.SelectedItem;
                ChangingRecord.date_begin = DateBeginDatePicker.SelectedDate;
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.departures.Where(filtercase => filtercase.tours.tour_name.Contains(Filter)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.departures.Where(filtercase => filtercase.date_begin.ToString().Contains(Filter)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
