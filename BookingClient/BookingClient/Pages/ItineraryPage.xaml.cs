using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class ItineraryPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;
        private string buf4;

        public ItineraryPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            TourIdComboBox.ItemsSource = SourceCore.entities.tours.ToList();
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

        public void UpdateDataGrid(itinerary SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (itinerary)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<itinerary>(SourceCore.entities.itinerary.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            TourIdComboBox.Text = "";
            DayNumTextBox.Text = "";
            ItineraryNameTextBox.Text = "";
            ItirararyDescriptionTextBox.Text = "";
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = TourIdComboBox.Text;
                buf2 = DayNumTextBox.Text;
                buf3 = ItineraryNameTextBox.Text;
                buf4 = ItirararyDescriptionTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                TourIdComboBox.Text = buf1;
                DayNumTextBox.Text = buf2;
                ItineraryNameTextBox.Text = buf3;
                ItirararyDescriptionTextBox.Text = buf4;
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
                    var DeletingRecord = (itinerary)RecordsDataGrid.SelectedItem;
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
                    var SelectingRecord = (itinerary)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.itinerary.Remove(DeletingRecord);
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
            var NewRecord = new itinerary();
            NewRecord.tours = (tours)TourIdComboBox.SelectedItem;
            NewRecord.day_num = Convert.ToInt32(DayNumTextBox.Text);
            NewRecord.itinerary_name = ItineraryNameTextBox.Text;
            NewRecord.itirarary_description = ItirararyDescriptionTextBox.Text;

            if (DlgMode == 0)
            {
                SourceCore.entities.itinerary.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (itinerary)RecordsDataGrid.SelectedItem;
                ChangingRecord.tours = (tours)TourIdComboBox.SelectedItem;
                ChangingRecord.day_num = Convert.ToInt32(DayNumTextBox.Text);
                ChangingRecord.itinerary_name = ItineraryNameTextBox.Text;
                ChangingRecord.itirarary_description = ItirararyDescriptionTextBox.Text;
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.itinerary.Where(filtercase => filtercase.tours.tour_name.Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.itinerary.Where(filtercase => filtercase.day_num.ToString().Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.itinerary.Where(filtercase => filtercase.itinerary_name.Contains(textbox)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.itinerary.Where(filtercase => filtercase.itirarary_description.Contains(textbox)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
