﻿using BookingClient.Models;
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
        private bool DlgMode = false;

        public ItineraryPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            TourIdComboBox.ItemsSource = SourceCore.entities.tours.ToList();
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

        private void TransferRecords()
        {
            var SelectedRecord = (itinerary)RecordsDataGrid.SelectedItem;
            TourIdComboBox.SelectedItem = SelectedRecord.tour_id;
            DayNumTextBox.Text = SelectedRecord.day_num.ToString();
            ItineraryNameTextBox.Text = SelectedRecord.itinerary_name;
            ItirararyDescriptionTextBox.Text = SelectedRecord.itirarary_description;
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordChangeTitle.Content = "Добавление";
            DlgMode = true;
            TourIdComboBox.Text = "";
            DayNumTextBox.Text = "";
            ItineraryNameTextBox.Text = "";
            ItirararyDescriptionTextBox.Text = "";
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

            if (DlgMode)
            {
                NewRecord.tours = (tours)TourIdComboBox.SelectedItem;
                NewRecord.day_num = Convert.ToInt32(DayNumTextBox.Text);
                NewRecord.itinerary_name = ItineraryNameTextBox.Text;
                NewRecord.itirarary_description = ItirararyDescriptionTextBox.Text;
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
