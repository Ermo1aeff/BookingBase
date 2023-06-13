using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using System.IO;
using BookingClient.Models;
using System.Data;
using System.Collections.ObjectModel;

namespace BookingClient.Pages
{
    public partial class ImagesPage : Page
    {
        public ImagesPage()
        {
            InitializeComponent();
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
        }

        public void UpdateListBox(images SelectingItem)
        {
            if ((SelectingItem == null) && (ImgListBox.ItemsSource != null))
            {
                SelectingItem = (images)ImgListBox.SelectedItem;
            }

            tours SelectedTours = (tours)RecordsDataGrid.SelectedItem;
            int tours_id = SelectedTours.tour_id;
            var ListBoxRecords = new ObservableCollection<images>(SourceCore.entities.images.Where(filtercase => filtercase.tour_id == tours_id).ToList());
            ImgListBox.ItemsSource = ListBoxRecords;
            ImgListBox.SelectedItem = SelectingItem;
            ImgListBox.Focus();
            ImgListBox.ScrollIntoView(SelectingItem);
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opndlgfl = new OpenFileDialog();
                opndlgfl.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                opndlgfl.Filter = "Image File (*.jpg;*.bmp;*.gif;*png)|*.jpg;*.bmp;*.gif;*.png";
                opndlgfl.Multiselect = true;
                opndlgfl.Title = "Выбор изображения";
                if (opndlgfl.ShowDialog() == true)
                {
                    int imgcnt = 0;
                    foreach (string filename in opndlgfl.FileNames)
                    {
                        ImageSourceConverter isc = new ImageSourceConverter();

                        FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        byte[] imgByteArr = new byte[fs.Length];
                        fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                        fs.Close();

                        images NewImage = new images();
                        NewImage.img = imgByteArr;
                        NewImage.tours = (tours)RecordsDataGrid.SelectedItem;
                        SourceCore.entities.images.Add(NewImage);
                        SourceCore.entities.SaveChanges();
                        UpdateListBox(NewImage);
                        imgcnt++;
                    }
                    MessageBox.Show("Добавлено изображений: " + imgcnt);
                }
                opndlgfl = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                try
                {
                    // Ссылка на удаляемую запись
                    var DeletingRecord = (images)ImgListBox.SelectedItem;
                    // Определение ссылки, на которую должен перейти указатель после удаления
                    if (ImgListBox.SelectedIndex < ImgListBox.Items.Count - 1)
                    {
                        ImgListBox.SelectedIndex++;
                    }
                    else
                    {
                        if (ImgListBox.SelectedIndex > 0)
                        {
                            ImgListBox.SelectedIndex--;
                        }
                    }

                    var SelectingRecord = (images)ImgListBox.SelectedItem;
                    SourceCore.entities.images.Remove(DeletingRecord);
                    SourceCore.entities.SaveChanges();
                    UpdateListBox(SelectingRecord);
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить запись, так как она используется в других справочниках базы данных.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                }
            }
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
