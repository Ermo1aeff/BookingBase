using BookingClient.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookingClient.Windows
{
    public partial class ProfileDlgWindow : Window
    {
        accounts Account { get; set; }
        BitmapImage bitmapImage;

        public ProfileDlgWindow(int AccountID)
        {
            InitializeComponent();
            Account = SourceCore.entities.accounts.FirstOrDefault(U => U.account_id == AccountID);

            if (Account.roles.roles_id == 3)
            {
                LastNameTextBox.Visibility = Visibility.Collapsed;
                FirstNameTextBox.Tag = "Название организации";
            }
            else
            {
                LastNameTextBox.Text = Account.last_names.last_name;
            }

            FirstNameTextBox.Text = Account.first_names.first_name;
            EmailTextBox.Text = Account.email;
            PhoneTextBox.Text = Account.phone.ToString();
            DateOfBirthDatePicker.Text = Account.dayofbirth.ToString();
            if (Account.image != null)
            {
                AvatarImageBrush.ImageSource = ToImage(Account.image);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;

            if (SourceCore.entities.last_names.Where(U => U.last_name == lastName).FirstOrDefault() == null)
            {
                last_names NewLastName = new last_names();
                NewLastName.last_name = lastName;
                SourceCore.entities.last_names.Add(NewLastName);
                SourceCore.entities.SaveChanges();
            }

            if (SourceCore.entities.first_names.Where(U => U.first_name == firstName).FirstOrDefault() == null)
            {
                first_names NewFirstName = new first_names();
                NewFirstName.first_name = firstName;
                SourceCore.entities.first_names.Add(NewFirstName);
                SourceCore.entities.SaveChanges();
            }

            Account.last_names = SourceCore.entities.last_names.Where(U => U.last_name == lastName).FirstOrDefault();
            Account.first_names = SourceCore.entities.first_names.Where(U => U.first_name == firstName).FirstOrDefault();

            Account.image = BitmapSourceToByteArray((BitmapSource)AvatarImageBrush.ImageSource);

            Account.phone = Convert.ToInt64(PhoneTextBox.Text);
            Account.email = EmailTextBox.Text;
            Account.dayofbirth = Convert.ToDateTime(DateOfBirthDatePicker.Text);

            SourceCore.entities.SaveChanges();
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ChangeAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opndlgfl = new OpenFileDialog();
                opndlgfl.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                opndlgfl.Filter = "Image File (*.jpg;*.bmp;*.gif;*png)|*.jpg;*.bmp;*.gif;*.png";
                opndlgfl.Multiselect = false;
                opndlgfl.Title = "Выбор изображения";
                if (opndlgfl.ShowDialog() == true)
                {
                    ImageSourceConverter isc = new ImageSourceConverter();

                    FileStream fs = new FileStream(opndlgfl.FileName, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    if (imgByteArr != null)
                    {
                        bitmapImage = ToImage(imgByteArr);

                        int RectX = 0;
                        int RectY = 0;
                        int RectWidth = 0;
                        int RectHeight = 0;

                        if (bitmapImage.PixelWidth > bitmapImage.PixelHeight)
                        {
                            RectX = (bitmapImage.PixelWidth - bitmapImage.PixelHeight) / 2;
                            RectY = 0;
                            RectWidth = bitmapImage.PixelHeight;
                            RectHeight = bitmapImage.PixelHeight;
                        }
                        else
                        {
                            RectX = 0;
                            RectY = (bitmapImage.PixelHeight - bitmapImage.PixelWidth) / 2;
                            RectWidth = bitmapImage.PixelWidth;
                            RectHeight = bitmapImage.PixelWidth;
                        }

                        CroppedBitmap cb = new CroppedBitmap(bitmapImage, new Int32Rect(RectX, RectY, RectWidth, RectHeight));

                        AvatarImageBrush.ImageSource = cb;
                    }
                }
                opndlgfl = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private byte[] BitmapSourceToByteArray(BitmapSource bmpSrc)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = 100;
            encoder.Frames.Add(BitmapFrame.Create(bmpSrc));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
