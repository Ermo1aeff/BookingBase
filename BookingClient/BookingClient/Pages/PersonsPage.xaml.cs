using BookingClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingClient.Pages
{
    public partial class PersonsPage : Page
    {
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;

        public PersonsPage()
        {
            InitializeComponent();
            DataContext = this;
            UpdateDataGrid(null);
            OrderIdComboBox.ItemsSource = SourceCore.entities.orders.ToList();
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

        public void UpdateDataGrid(persons SelectingItem)
        {
            if ((SelectingItem == null) && (RecordsDataGrid.ItemsSource != null))
            {
                SelectingItem = (persons)RecordsDataGrid.SelectedItem;
            }
            var DataGridRecords = new ObservableCollection<persons>(SourceCore.entities.persons.ToList());
            RecordsDataGrid.ItemsSource = DataGridRecords;
            RecordsDataGrid.SelectedItem = SelectingItem;
        }


        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(true);
            DlgMode = 0;
            RecordsDataGrid.SelectedItem = null;
            RecordChangeTitle.Content = "Добавление";
            LastNameTextBox.Text = "";
            FirstNameTextBox.Text = "";
            PassportTextBox.Text = "";
            DateOfBirthDatePicker.SelectedDate = DateTime.Now;
        }

        private void CopyRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem != null)
            {
                DlgLoad(true);
                DlgMode = 0;
                RecordChangeTitle.Content = "Копирование";

                //использование буферных переменных для «отрыва» от данных выбранной строки (чтобы не сработал Binding)
                buf1 = LastNameTextBox.Text;
                buf2 = FirstNameTextBox.Text;
                buf3 = PassportTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                LastNameTextBox.Text = buf1;
                FirstNameTextBox.Text = buf2;
                FirstNameTextBox.Text = buf3;
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
                    var DeletingRecord = (persons)RecordsDataGrid.SelectedItem;
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

                    var SelectingRecord = (persons)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.persons.Remove(DeletingRecord);
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
            var NewRecord = new persons();
            NewRecord.orders = (orders)OrderIdComboBox.SelectedItem;
            NewRecord.last_name = LastNameTextBox.Text;
            NewRecord.first_name = FirstNameTextBox.Text;
            NewRecord.passport = Convert.ToInt64(PassportTextBox.Text);
            NewRecord.birthday = DateOfBirthDatePicker.SelectedDate;  // Date of birth, not birthday.

            if (DlgMode == 0)
            {
                SourceCore.entities.persons.Add(NewRecord);
            }
            else
            {
                var ChangingRecord = (persons)RecordsDataGrid.SelectedItem;
                ChangingRecord.orders = (orders)OrderIdComboBox.SelectedItem;
                ChangingRecord.last_name = LastNameTextBox.Text;
                ChangingRecord.first_name = FirstNameTextBox.Text;
                ChangingRecord.passport = Convert.ToInt64(PassportTextBox.Text);
                ChangingRecord.birthday = DateOfBirthDatePicker.SelectedDate;
            }
            SourceCore.entities.SaveChanges();
            //int orderId = (int)NewRecord.order_id;
            //var order = SourceCore.entities.orders.Where(U => U.order_id == orderId).FirstOrDefault();

            //order.person_count = SourceCore.entities.persons.Count(U => U.order_id == orderId);

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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.orders.order_id.ToString().Contains(textbox)).ToList();
                    break;
                case 1:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.last_name.Contains(textbox)).ToList();
                    break;
                case 2:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.first_name.Contains(textbox)).ToList();
                    break;
                case 3:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.passport.ToString().Contains(textbox)).ToList();
                    break;
                case 4:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.persons.Where(filtercase => filtercase.birthday.ToString().Contains(textbox)).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
