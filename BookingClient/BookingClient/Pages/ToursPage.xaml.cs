using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookingClient.Models;

namespace BookingClient.Pages
{
    /// <summary>
    /// Interaction logic for ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        //описание вспомогательных переменных
        private int DlgMode = -1;
        private string buf1;
        private string buf2;
        private string buf3;
        private string buf4;
        private string buf5;
        private string buf6;
        private string buf7;
        private string buf8;

        public ToursPage()
        {
            InitializeComponent();
            DataContext = this;
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            BeginCityComboBox.ItemsSource = SourceCore.entities.cities.ToList();
            EndCityTextBox.ItemsSource = SourceCore.entities.cities.ToList();
        }

        public void DlgLoad(bool b)
        {
            if (b == true)
            {
                RecordChangeBlock.MinWidth = 230;
                RecordChangeBlock.Width = new GridLength(230);
                //Включаем кнопки
                RecordsDataGrid.IsHitTestVisible = false;
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
                //Выключаем кнопки
                RecordsDataGrid.IsHitTestVisible = true;
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
            //EndCityTextBox.Text = "";
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
                //buf3 = EndCityTextBox.Text;
                buf4 = PriceTextBox.Text;
                buf5 = DayCountTextBox.Text;
                buf6 = MaxGroupSizeTextBox.Text;

                //убрать фокус с выделенной строки
                RecordsDataGrid.SelectedItem = null;

                TourNameTextBox.Text = buf1;
                TourDescriptionTextBox.Text = buf2;
                //EndCityTextBox.Text = buf3;
                PriceTextBox.Text = buf4;
                DayCountTextBox.Text = buf5;
                MaxGroupSizeTextBox.Text = buf6;
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
                SourceCore.entities.tours.Remove((tours)RecordsDataGrid.SelectedItem);
                SourceCore.entities.SaveChanges();
                RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            }
        }

        private void CommitChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(RecordChangeTitle.Content) == "Добавление")
            {
                var NewTour = new tours();
                NewTour.tour_name = TourNameTextBox.Text;
                NewTour.tour_description = TourDescriptionTextBox.Text;
                NewTour.cities = (cities)BeginCityComboBox.SelectedItem;
                //NewTour.price = Convert.ToDecimal(PriceTextBox.Text);
                NewTour.day_count = Convert.ToInt32(DayCountTextBox.Text);
                NewTour.max_group_size = Convert.ToInt32(MaxGroupSizeTextBox.Text);
                SourceCore.entities.tours.Add(NewTour);
            }
            SourceCore.entities.SaveChanges();

            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            DlgLoad(false);
        }

        private void RollbackChangeRecordsButton_Click(object sender, RoutedEventArgs e)
        {
            DlgLoad(false);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> Columns = new List<string>();
            for (int I = 0; I < 5; I++)
            {
                Columns.Add(RecordsDataGrid.Columns[I].Header.ToString());
            }
            FilterComboBox.ItemsSource = Columns;
            FilterComboBox.SelectedIndex = 0;
            //foreach (DataGridColumn Column in RecordsDataGrid.Columns)
            //{
            //    Column.CanUserSort = false;
            //}

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
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.price.ToString().Contains(textbox)).ToList();
                    break;
                case 4:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.day_count.ToString().Contains(textbox)).ToList();
                    break;
                case 5:
                    RecordsDataGrid.ItemsSource = SourceCore.entities.tours.Where(filtercase => filtercase.max_group_size.ToString().Contains(textbox)).ToList();
                    break;
            }
        }
    }
}
