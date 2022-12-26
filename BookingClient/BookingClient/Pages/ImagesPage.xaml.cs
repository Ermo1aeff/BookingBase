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
        List<string> deepImgList = new List<string>();
        string strName;
        string imageName;
        DataSet ds;
        string constr = @"data source=ERMOLAEV;initial catalog=Booking_Base;integrated security=True";

        public ImagesPage()
        {
            InitializeComponent();
            RecordsDataGrid.ItemsSource = SourceCore.entities.tours.ToList();
            //imgList.ItemsSource = SourceCore.entities.images.ToList();
            //BindImageList();
        }



        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*png)|*.jpg;*.bmp;*.gif;*.png";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            try
            {
                if (imageName != "")
                {
                    //Initialize a file stream to read the image file
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    byte[] imgByteArr = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();

                    var NewImage = new images();
                    NewImage.img = imgByteArr;
                    NewImage.tours = (tours)RecordsDataGrid.SelectedItem;
                    SourceCore.entities.images.Add(NewImage);
                    SourceCore.entities.SaveChanges();
                    imgList.ItemsSource = SourceCore.entities.images.ToList();

                    //using (SqlConnection conn = new SqlConnection(constr))
                    //{
                    //    conn.Open();
                    //    string sql = "insert into tbl_Image(id,img) values('" + strName + "',@img)";
                    //    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    //    {
                    //        //Pass byte array into database
                    //        cmd.Parameters.Add(new SqlParameter("img", imgByteArr));
                    //        int result = cmd.ExecuteNonQuery();
                    //        if (result == 1)
                    //        {
                    //            MessageBox.Show("Image added successfully.");
                    //            //BindImageList();
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void insertImageData()
        {
            
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
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();

                ds = new DataSet("myDataSet");
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM images", conn);
                adapter.Fill(ds);
                DataTable dataTable = ds.Tables[0];

                foreach (DataRow row in dataTable.Rows)
                {
                    images im = (images)imgList.SelectedItem;
                    if (row[0].ToString() == im.image_id.ToString())
                    {
                        //Store binary data read from the database in a byte array
                        byte[] blob = (byte[])row[2];
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

        private void BindImageList()
        {
            try
            {
                SqlConnection conn = new SqlConnection(constr);

                conn.Open();

                ds = new DataSet("myDataSet");
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM images", conn);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];

                //cbImages.Items.Clear();
                deepImgList.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    //cbImages.Items.Add(dr["id"].ToString());
                    deepImgList.Add(dr["id"].ToString());
                }
                //cbImages.SelectedIndex = 0;
                imgList.ItemsSource = SourceCore.entities.images.ToList();

                var tours = (tours)RecordsDataGrid.SelectedItem;

                imgList.ItemsSource = SourceCore.entities.images.Where(filtercase => filtercase.tours.tour_id.ToString().Contains(tours.ToString())).ToList();
                //imgList.ItemsSource = SourceCore.entities.images.Where(filtercase => filtercase.tours.tour_id.ToString().Contains(1.ToString()).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecordsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tours1 = (tours)RecordsDataGrid.SelectedItem;
            int tours_id = tours1.tour_id;
            //MessageBox.Show(tours1.tour_id.ToString());
            imgList.ItemsSource = SourceCore.entities.images.Where(filtercase => filtercase.tour_id.ToString().Contains(tours_id.ToString())).ToList();
        }
    }
}
