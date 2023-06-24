using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class InclusionsPage : Page
    {
        private bool DlgMode = false;

        public InclusionsPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
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

        public void UpdateDataGrid(inclusions SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (inclusions)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<inclusions>(SourceCore.entities.inclusions.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }

        private void TransferRecords()
        {
            var SelectedRecord = (inclusions)RecordsDataGrid.SelectedItem;
            InclusionNameTextBox.Text = SelectedRecord.inclusion_name;
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordChangeTitle.Content = "Добавление";
            DlgMode = true;
            InclusionNameTextBox.Text = "";
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
                    var DeletingRecord = (inclusions)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (inclusions)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.inclusions.Remove(DeletingRecord);
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
            var NewRecord = new inclusions();

            if (DlgMode)
            {
                NewRecord.inclusion_name = InclusionNameTextBox.Text;
                SourceCore.entities.inclusions.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (inclusions)RecordsDataGrid.SelectedItem;
                ChangingRecord.inclusion_name = InclusionNameTextBox.Text;
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.inclusions.Where(filtercase => filtercase.inclusion_name.ToString().Contains(textbox)).ToList();
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
