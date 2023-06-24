﻿using BookingClient.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class CountriesPage : Page
    {
        private bool DlgMode = false;

        public CountriesPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
        }

        public void UpdateDataGrid(countries SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (countries)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<countries>(SourceCore.entities.countries.ToList());
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
            var SelectedRecord = (countries)RecordsDataGrid.SelectedItem;
            CountryNameTextBox.Text = SelectedRecord.country_name;
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordChangeTitle.Content = "Добавление";
            DlgMode = true;
            RecordsDataGrid.SelectedItem = null;
            CountryNameTextBox.Text = "";
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
                    var DeletingRecord = (countries)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (countries)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.countries.Remove(DeletingRecord);
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
            var NewRecord = new countries();

            if (DlgMode)
            {
                NewRecord.country_name = CountryNameTextBox.Text;
                SourceCore.entities.countries.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (countries)RecordsDataGrid.SelectedItem;
                ChangingRecord.country_name = CountryNameTextBox.Text;
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.countries.Where(filtercase => filtercase.country_name.Contains(Filter)).ToList();
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
