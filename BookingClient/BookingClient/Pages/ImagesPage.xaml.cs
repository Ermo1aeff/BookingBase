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
using Microsoft.Win32;
using System.Windows.Shapes;
using System.IO;
using System.Data.SqlClient;
using BookingClient.Models;
using System.Data;
using System.Drawing.Imaging;

namespace BookingClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для ImagesPage.xaml
    /// </summary>
    public partial class ImagesPage : Page
    {
        public ImagesPage()
        {
            InitializeComponent();
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
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
                        imgList.ItemsSource = SourceCore.entities.images.ToList();
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

        private void EditRecordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void imgList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imgList.SelectedItem != null)
            {

                foreach (images row in SourceCore.entities.images)
                {
                    images im = (images)imgList.SelectedItem;
                    if (row.image_id.ToString() == im.image_id.ToString())
                    {
                        byte[] blob = row.img;
                        MemoryStream stream = new MemoryStream();
                        stream.Write(blob, 0, blob.Length);
                        stream.Position = 0;

                        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();

                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, ImageFormat.Bmp);
                        ms.Seek(0, SeekOrigin.Begin);
                        bi.StreamSource = ms;
                        bi.EndInit();
                        image.Source = bi;
                    }
                }
            }
        }
        private void RecordsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tours tours1 = (tours)RecordsDataGrid.SelectedItem;
            int tours_id = tours1.tour_id;
            imgList.ItemsSource = SourceCore.entities.images.Where(filtercase => filtercase.tour_id.ToString().Contains(tours_id.ToString())).ToList();
        }
    }
}
