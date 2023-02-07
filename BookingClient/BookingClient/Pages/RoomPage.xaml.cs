using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class RoomPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;
        private string buf4;

        public RoomPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            TourNameComboBox.ItemsSource = SourceCore.entities.tours.ToList();
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

        public void UpdateDataGrid(rooms SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (rooms)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<rooms>(SourceCore.entities.rooms.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }


        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            TourNameComboBox.Text = "";
            RoomNameTextBox.Text = "";
            BedsCountTextBox.Text = "";
            PriceTextBox.Text = "";
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
                buf2 = RoomNameTextBox.Text;
                buf3 = BedsCountTextBox.Text;
                buf4 = PriceTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                TourNameComboBox.Text = buf1;
                RoomNameTextBox.Text = buf2;
                BedsCountTextBox.Text = buf3;
                PriceTextBox.Text = buf4;
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
                    var DeletingRecord = (rooms)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (rooms)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.rooms.Remove(DeletingRecord);
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
            var NewRecord = new rooms();
            NewRecord.tours = (tours)TourNameComboBox.SelectedItem;
            NewRecord.room_name = RoomNameTextBox.Text;
            NewRecord.beds_count = Convert.ToInt32(BedsCountTextBox.Text);
            NewRecord.price = Convert.ToDecimal(PriceTextBox.Text);

            if (DlgMode == 0)
            {
                SourceCore.entities.rooms.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (rooms)RecordsDataGrid.SelectedItem;
                ChangingRecord.tours = (tours)TourNameComboBox.SelectedItem;
                ChangingRecord.room_name = RoomNameTextBox.Text;
                ChangingRecord.beds_count = Convert.ToInt32(BedsCountTextBox.Text);
                ChangingRecord.price = Convert.ToDecimal(PriceTextBox.Text);
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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.rooms.Where(filtercase => filtercase.tours.tour_name.Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.rooms.Where(filtercase => filtercase.room_name.Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.rooms.Where(filtercase => filtercase.beds_count.ToString() == textbox || (textbox == "" ? true : false)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.rooms.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                case 4:
                default:
                    break;
            }
        }
    }
}
